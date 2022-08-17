using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectEntra21.src.Application.Query.Cells;
using ProjectEntra21.src.Application.Request.Cells;
using ProjectEntra21.src.Application.ViewModels;
using ProjectEntra21.src.Domain.Common;
using System;
using System.Threading.Tasks;

namespace ProjectEntra21.src.Presentation.Controllers
{
    public class CellsController : Entra21Controller
    {
        public CellsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<ActionResult<PaginationResponse<CellViewModel>>> GetSelectAll([FromQuery] FilterBase filterBase)
        {
            try
            {
                return await _mediator.Send(new GetAllCellQuery { Filters = filterBase });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{codeCell}")]
        public async Task<CellViewModel> GetSelectOneAsync([FromRoute] int codeCell)
        {
            return await _mediator.Send(new GetOneCellQuery { CodeCell = codeCell });
        }

        [HttpPost]
        public async Task<IActionResult> PostCellAsync([FromBody] PersistCellCommand persistCellCommand)
        {
            if (persistCellCommand == null)

                return BadRequest();

            var response = await _mediator.Send(persistCellCommand);
            var absolutePath = string.Format("{0}://{1}{2}", Request.Scheme, Request.Host, Request.Path.Value);
            return Created(new Uri(absolutePath + "/" + response.CodeCell), response);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] PersistCellCommand persistCellCommand)
        {
            if (persistCellCommand == null)

                return BadRequest();

            return Ok(await _mediator.Send(persistCellCommand));
        }

        [HttpDelete]
        [Route("{codeCell}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int codeCell)
        {
            await _mediator.Send(new DeleteOneCellCommand { CodeCell = codeCell });

            return NoContent();
        }
    }
}
