﻿using MediatR;
using ProjectEntra21.src.Application.Database;
using ProjectEntra21.src.Application.Exceptions;
using ProjectEntra21.src.Domain.Entiteis;
using ProjectEntra21.src.Domain.Enums;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEntra21.src.Application.Request.Orders
{
    public class PersistOrderCommand : IRequest<Order>
    {
        public long RegisterEmployeer { get; set; }
        public long CodeProduct { get; set; }
        public int AmountEnter { get; set; }
        public PhaseCell Phase { get; set; }
    }

    public class PersistOrderCommandHandler : IRequestHandler<PersistOrderCommand, Order>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICellEmployeerRepository _cellEmployeerRepository;
        private readonly IProductRepository _productRepository;
        private readonly IEmployeerRepository _employeerRepository;
        private readonly ICellRepository _cellRepository;
        private readonly ITotalPartialRepository _totalPartialRepository;

        public PersistOrderCommandHandler(IOrderRepository orderRepository, ICellEmployeerRepository cellEmployeerRepository,
            IProductRepository productRepository, IEmployeerRepository employeerRepository, ICellRepository cellRepository, ITotalPartialRepository totalPartialRepository)
        {
            _orderRepository = orderRepository;
            _cellEmployeerRepository = cellEmployeerRepository;
            _productRepository = productRepository;
            _employeerRepository = employeerRepository;
            _cellRepository = cellRepository;
            _totalPartialRepository = totalPartialRepository;
        }

        public async Task<Order> Handle(PersistOrderCommand request, CancellationToken cancellationToken)
        {

            CellEmployeer cellEmployeer = await _cellEmployeerRepository.SelectOne(x => x.Employeer.Register == request.RegisterEmployeer && x.Phase == request.Phase && x.Cell.StatusCell == StatusCell.Ativa);

            if (cellEmployeer == null)
                throw new NullReferenceException($"O operador não está na fase {request.Phase} ou a célula não está ativa, verifique as operações do dia {DateTime.Now.ToShortDateString()}!");


            cellEmployeer = await _cellEmployeerRepository.SelectOne(x => x.Employeer.Register == request.RegisterEmployeer
             && x.CreateAt >= DateTime.Now.Date
                    && x.CreateAt < DateTime.Now.Date.AddDays(1));


            if (cellEmployeer == null)
            {
                Employeer employeer = await _employeerRepository.SelectOne(x => x.Register == request.RegisterEmployeer);

                if (employeer == null)
                    throw new NullReferenceException("Funcionario não encontrado !");

                cellEmployeer = await _cellEmployeerRepository.SelectOneEmployeer(request.RegisterEmployeer);

                if (cellEmployeer == null)
                    throw new NullReferenceException("Funcionario não está nacadastrado na operação !");

                Cell cell = await _cellRepository.SelectOne(x => x.CodeCell == cellEmployeer.Cell.CodeCell);

                if (cell == null)
                    throw new NullReferenceException("Célula não encontrada !");


                cellEmployeer = new CellEmployeer
                {
                    Cell = cell,
                    Employeer = employeer,
                    Phase = request.Phase
                };

                await _cellEmployeerRepository.InsertOrUpdate(cellEmployeer);
            }

            Product product = await _productRepository.SelectOne(x => x.Code == request.CodeProduct);

            if (product == null)
                throw new NullReferenceException("Produto não encontrado !");


            if (request.AmountEnter == 0)
                return null;


            Order order = await _orderRepository.SelectOne(x => x.CellEmployeer.Employeer.Register == request.RegisterEmployeer
                && x.Product.Code == request.CodeProduct && x.CreateAt >= DateTime.Now.Date
                    && x.CreateAt < DateTime.Now.Date.AddDays(1) && x.CellEmployeer.Phase == request.Phase);

            if (order == null)
            {
                order = new Order
                {
                    CellEmployeer = cellEmployeer,
                    Product = product
                };
            }

            int phase = (int)request.Phase;

            switch (phase)
            {
                case 1:

                    order.AmountEnter += request.AmountEnter;
                    break;

                case 2:
                case 3:

                    TotalPartial totalFinished = await _totalPartialRepository.SelectTotalPartial(phase - 1, request.CodeProduct);

                    if (totalFinished == null)
                        throw new NullReferenceException($"Não foi produzido nenhum produto na fase {request.Phase - 1} !");


                    if (totalFinished.Total >= request.AmountEnter)
                    {
                        order.AmountEnter += request.AmountEnter;
                        totalFinished.Total -= request.AmountEnter;

                        await _totalPartialRepository.Update(totalFinished);
                    }
                    else
                        throw new ValueNotAvailableException($"A entrada de {request.AmountEnter} BigBag na fase {request.Phase}, é maior que o disponivel da fase {request.Phase - 1} !");

                    break;

                default:

                    break;

            }
            await _orderRepository.InsertOrUpdate(order);

            return order;
        }
    }
}
