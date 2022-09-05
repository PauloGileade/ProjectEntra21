﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectEntra21.src.Application.Database;
using ProjectEntra21.src.Application.ViewModels;
using ProjectEntra21.src.Domain.Common;
using ProjectEntra21.src.Domain.Entiteis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEntra21.src.Application.Query.Orders
{
    public class GetAllOrderByRegisterQuery : IRequest<PaginationResponse<OrderViewModel>>
    {
        public long RegisterEmployeer { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public FilterBase Filters { get; set; }
    }

    public class GetAllOrderByRegisterQueryHandler : IRequestHandler<GetAllOrderByRegisterQuery, PaginationResponse<OrderViewModel>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetAllOrderByRegisterQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<PaginationResponse<OrderViewModel>> Handle(GetAllOrderByRegisterQuery request, CancellationToken cancellationToken)
        {

            var queryResult = await _orderRepository.SelectAllByRegister(request.RegisterEmployeer, request.DateStart, request.DateEnd, request.Filters);
            var mappedItems = _mapper.Map<IEnumerable<Order>>(queryResult.Data);

            List<OrderViewModel> list = new();

            foreach (var mappedItem in mappedItems)
            {
                list.Add(new OrderViewModel
                {
                    CodeCell = mappedItem.CellEmployeer.Cell.CodeCell,
                    CodeProduct = mappedItem.Product.Code,
                    NameProduct = mappedItem.Product.Name,
                    RegisterEmployeer = mappedItem.CellEmployeer.Employeer.Register,
                    NameEmployeer = mappedItem.CellEmployeer.Employeer.Name,
                    AmountEnter = mappedItem.AmountEnter,
                    AmountFinished = mappedItem.AmountFinished,
                    Phase = mappedItem.CellEmployeer.Phase.ToString(),
                    CreatAt = mappedItem.CreateAt.Date.ToShortDateString()
                });
            }

            return new PaginationResponse<OrderViewModel>(list, queryResult.TotalItems,
                    queryResult.CurrentPage, request.Filters._size);
        }
    }
}