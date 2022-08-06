using MediatR;
using Microsoft.AspNetCore.Mvc;
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
        [Route("{code}")]
        public async Task<OrderViewModel> GetSelectOneAsync([FromRoute] long code)
        {
            return await _mediator.Send(new GetOneOrderQuery { Code = code });
        }

        [HttpPost]
        public async Task<IActionResult> PostProductAsync([FromBody] PersistOrderCommand persistOrderRequest)
        {
            if (persistOrderRequest == null)

                return BadRequest();

            var response = await _mediator.Send(persistOrderRequest);
            var absolutePath = string.Format("{0}://{1}{2}", Request.Scheme, Request.Host, Request.Path.Value);
            return Created(new Uri(absolutePath + "/" + response.Code), response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] PersistOrderCommand persistOrderRequest)
        {
            if (persistOrderRequest == null)

                return BadRequest();

            return Ok(await _mediator.Send(persistOrderRequest));
        }
    }
}
