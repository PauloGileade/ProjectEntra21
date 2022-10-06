using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectEntra21.src.Application.Command.Orders;
using ProjectEntra21.src.Application.Exceptions;
using ProjectEntra21.src.Application.Query.Orders;
using ProjectEntra21.src.Application.Request.Orders;
using ProjectEntra21.src.Application.ViewModels;
using ProjectEntra21.src.Domain.Common;
using System;
using System.Threading.Tasks;

namespace ProjectEntra21.src.Presentation.Controllers
{
    public class OrdersController : Entra21Controller
    {
        public OrdersController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<ActionResult<PaginationResponse<OrderViewModel>>> GetAllOrder([FromQuery] FilterBase filterBase)
        {
            try
            {
                return await _mediator.Send(new GetAllOrderQuery { Filters = filterBase });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{codeCell}/{date}")]
        public async Task<ActionResult<PaginationResponse<OrderViewModel>>> GetAllOrderByCodecellAsync([FromRoute] long codeCell, DateTime date,
                 [FromQuery] FilterBase filterBase)
        {
            try
            {
                return await _mediator.Send(new GetAllOrderByCodecellQuery { CodeCell = codeCell, Date = date, Filters = filterBase });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{dateStart}/{dateEnd}/{register}")]
        public async Task<ActionResult<PaginationResponse<OrderViewModel>>> GetAllOrderByRegisterAsync([FromRoute] DateTime dateStart, DateTime dateEnd, long register,
             [FromQuery] FilterBase filterBase)
        {
            try
            {
                return await _mediator.Send(new GetAllOrderByRegisterQuery { RegisterEmployeer = register, DateStart = dateStart, DateEnd = dateEnd, Filters = filterBase });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{register}/{codeProduct}/{dateStart}/{dateEnd}")]
        public async Task<ActionResult<OrderViewModel>> GetOneOrderByRegisterAsync([FromRoute] long register, long codeProduct, DateTime dateStart, DateTime dateEnd)
        {
            try
            {
                return await _mediator.Send(new GetOneOrderByRegisterQuery { RegisterEmployeer = register, CodeProduct = codeProduct, DateStart = dateStart, DateEnd = dateEnd });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostOrdemAsync([FromBody] PersistOrderCommand persistOrderCommand)
        {

            if (persistOrderCommand == null)
                return BadRequest();

            try
            {
                var response = await _mediator.Send(persistOrderCommand);

                var absolutePath = string.Format("{0}://{1}{2}", Request.Scheme, Request.Host, Request.Path.Value);
                return Created(new Uri(absolutePath + "/" + response.Code), response);
            }
            catch(NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (ValueNotAvailableException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] PersistOrderCommand persistOrderCommand)
        {
            if (persistOrderCommand == null)

                return BadRequest();

            return Ok(await _mediator.Send(persistOrderCommand));
        }

        [HttpPut]
        [Route("{codeQrcode}")]
        public async Task<IActionResult> UpdateAmountFinishedAsync([FromRoute] string codeQrcode)
        {
            if (codeQrcode == null)
                return NotFound();


            string[] vect = codeQrcode.Split(';');

            return Ok(await _mediator.Send(new UpdateAmountFinishedCommand
            {
                RegisterEmployeer = long.Parse(vect[0]),
                CodeProduct = long.Parse(vect[1]),
                Phase = vect[2],
                Cell = long.Parse(vect[3])
            }));
        }
    }
}
