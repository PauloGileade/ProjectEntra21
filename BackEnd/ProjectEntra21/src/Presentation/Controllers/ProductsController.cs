using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectEntra21.src.Application.Query.Products;
using ProjectEntra21.src.Application.Request.Products;
using ProjectEntra21.src.Application.ViewModels;
using ProjectEntra21.src.Domain.Common;
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
        public async Task<ActionResult<PaginationResponse<ProductViewModel>>> GetSelectAll([FromQuery] FilterBase filterBase)
        {
            try
            {
                return await _mediator.Send(new GetAllProductQuery { Filters = filterBase });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{code}")]
        public async Task<ActionResult<ProductViewModel>> GetSelectOneAsync([FromRoute] long code)
        {
            try
            {
                return await _mediator.Send(new GetOneProductQuery { Code = code });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostProductAsync([FromBody] PersistProductRequest persistProductCommand)
        {
            if (persistProductCommand == null)

                return BadRequest();

            var response = await _mediator.Send(persistProductCommand);
            var absolutePath = string.Format("{0}://{1}{2}", Request.Scheme, Request.Host, Request.Path.Value);
            return Created(new Uri(absolutePath + "/" + response.Code), response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] PersistProductRequest persistProductCommand)
        {
            if (persistProductCommand == null)

                return BadRequest();

            return Ok(await _mediator.Send(persistProductCommand));
        }

        [HttpDelete]
        [Route("{code}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] long code)
        {
            await _mediator.Send(new DeleteOneProductCommand { Code = code });

            return NoContent();
        }
    }
}
