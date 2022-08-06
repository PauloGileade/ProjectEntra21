using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectEntra21.src.Application.Query.CellEmployeers;
using ProjectEntra21.src.Application.Request.CellEmployeers;
using ProjectEntra21.src.Application.ViewModels;
using ProjectEntra21.src.Domain.Common;
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
        public async Task<ActionResult<PaginationResponse<CellEmployeerViewModel>>> GetSelectAll([FromQuery] FilterBase filterBase)
        {
            try
            {
                return await _mediator.Send(new GetAllCellEmployeerQuery { Filters = filterBase });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{code}")]
        public async Task<CellEmployeerViewModel> GetSelectOneAsync([FromRoute] int code)
        {
            return await _mediator.Send(new GetOneCellEmployeerQuery { Code = code });
        }

        [HttpPost]
        public async Task<IActionResult> PostCellEmployeerAsync([FromBody] PersistCellEmployeerCommand persistCellEmployeerRequest)
        {
            if (persistCellEmployeerRequest == null)

                return BadRequest();

            var response = await _mediator.Send(persistCellEmployeerRequest);
            var absolutePath = string.Format("{0}://{1}{2}", Request.Scheme, Request.Host, Request.Path.Value);
            return Created(new Uri(absolutePath + "/" + response.Id), response);
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
