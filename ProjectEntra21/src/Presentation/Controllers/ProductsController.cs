using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectEntra21.src.Application.Request.Products;
using ProjectEntra21.src.Application.ViewModels;
using System;
using System.Threading.Tasks;

namespace ProjectEntra21.src.Presentation.Controllers
{
    public class ProductsController : Entra21Controller
    {
        public ProductsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("{code}")]
        public async Task<GetProductViewModel> GetSelectOneAsync([FromRoute] long code)
        {
            return await _mediator.Send(new GetOneProductRequest { Code = code });
        }

        [HttpPost]
        public async Task<IActionResult> PostProductAsync([FromBody] PersistProductRequest persistProductRequest)
        {
            if (persistProductRequest == null)

                return BadRequest();

            var response = await _mediator.Send(persistProductRequest);
            var absolutePath = string.Format("{0}://{1}{2}", Request.Scheme, Request.Host, Request.Path.Value);
            return Created(new Uri(absolutePath + "/" + response.Code), response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] PersistProductRequest persistProductRequest)
        {
            if (persistProductRequest == null)

                return BadRequest();

            return Ok(await _mediator.Send(persistProductRequest));
        }

        [HttpDelete]
        [Route("{code}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] long code)
        {
            await _mediator.Send(new DeleteOneProductRequest { Code = code });

            return NoContent();
        }
    }
}
