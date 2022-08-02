using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectEntra21.src.Application.Request.Cells;
using ProjectEntra21.src.Application.ViewModels;
using System;
using System.Threading.Tasks;

namespace ProjectEntra21.src.Presentation.Controllers
{
    public class CellsController : Entra21Controller
    {
        public CellsController(IMediator mediator) : base(mediator)
        {
        }
        /*
        [HttpGet]
        public async Task<IList<Cell>> GetSelectMore()
        {
            return await _cellRepository.SelectMore();
        }
        */

        [HttpGet]
        [Route("{codeCell}")]
        public async Task<GetCellViewModel> GetSelectOneAsync([FromRoute] int codeCell)
        {
            return await _mediator.Send(new GetOneCell { CodeCell = codeCell });
        }

        [HttpPost]
        public async Task<IActionResult> PostCellAsync([FromBody] PersistCellRequest persistCellRequest)
        {
            if (persistCellRequest == null)

                return BadRequest();

            var response = await _mediator.Send(persistCellRequest);
            var absolutePath = string.Format("{0}://{1}{2}", Request.Scheme, Request.Host, Request.Path.Value);
            return Created(new Uri(absolutePath + "/" + response.CodeCell), response);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] PersistCellRequest persistCellRequest)
        {
            if (persistCellRequest == null)

                return BadRequest();

            return Ok(await _mediator.Send(persistCellRequest));
        }

        [HttpDelete]
        [Route("{codeCell}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int codeCell)
        {
            await _mediator.Send(new DeleteOneCellRequest { CodeCell = codeCell });

            return NoContent();
        }
    }
}
