using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectEntra21.src.Application.Query.CellEmployeers;
using ProjectEntra21.src.Application.Request.CellEmployeers;
using ProjectEntra21.src.Application.ViewModels;
using ProjectEntra21.src.Domain.Common;
using ProjectEntra21.src.Domain.Enums;
using System;
using System.Threading.Tasks;

namespace ProjectEntra21.src.Presentation.Controllers
{
    public class CellEmployeersController : Entra21Controller
    {
        public CellEmployeersController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("{codeCell}/{date}")]
        public async Task<ActionResult<PaginationResponse<CellEmployeerViewModel>>> GetSelectMoreAsync([FromRoute] long codeCell, DateTime date,
                [FromQuery] FilterBase filterBase)
        {
            try
            {
                return await _mediator.Send(new GetOneCellEmployeerQuery { CodeCell = codeCell, Date = date, Filters = filterBase });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostCellEmployeerAsync([FromBody] PersistCellEmployeerCommand persistCellEmployeerCommand)
        {
            if (persistCellEmployeerCommand == null)
                return BadRequest();

            try
            {
                var response = await _mediator.Send(persistCellEmployeerCommand);

                var absolutePath = string.Format("{0}://{1}{2}", Request.Scheme, Request.Host, Request.Path.Value);
                return Created(new Uri(absolutePath + "/" + response.Code), response);
            }
            catch (NullReferenceException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] PersistCellEmployeerCommand persistCellEmployeerRequest)
        {
            if (persistCellEmployeerRequest == null)

                return BadRequest();

            return Ok(await _mediator.Send(persistCellEmployeerRequest));
        }
        [HttpDelete]
        [Route("{code}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int code)
        {
            await _mediator.Send(new DeleteOneCellEmployeerCommand { Code = code });

            return NoContent();
        }
    }
}
