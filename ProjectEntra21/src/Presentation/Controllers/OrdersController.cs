using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectEntra21.src.Application.Request.Orders;
using ProjectEntra21.src.Application.ViewModels;
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
        [Route("{code}")]
        public async Task<GetOrderViewModel> GetSelectOneAsync([FromRoute] long code)
        {
            return await _mediator.Send(new GetOneOrderRequest { Code = code });
        }

        [HttpPost]
        public async Task<IActionResult> PostProductAsync([FromBody] PersistOrderRequest persistOrderRequest)
        {
            if (persistOrderRequest == null)

                return BadRequest();

            var response = await _mediator.Send(persistOrderRequest);
            var absolutePath = string.Format("{0}://{1}{2}", Request.Scheme, Request.Host, Request.Path.Value);
            return Created(new Uri(absolutePath + "/" + response.Code), response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] PersistOrderRequest persistOrderRequest)
        {
            if (persistOrderRequest == null)

                return BadRequest();

            return Ok(await _mediator.Send(persistOrderRequest));
        }
    }
}
