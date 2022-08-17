using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectEntra21.src.Application.Database;
using ProjectEntra21.src.Application.Query.Employeers;
using ProjectEntra21.src.Application.Request.Employeers;
using ProjectEntra21.src.Application.ViewModels;
using ProjectEntra21.src.Domain.Common;
using ProjectEntra21.src.Domain.Entiteis;
using System;
using System.Threading.Tasks;

namespace ProjectEntra21.src.Presentation.Controllers
{
    public class EmployeersController : Entra21Controller
    {

        public EmployeersController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<ActionResult<PaginationResponse<EmployeerViewModel>>> GetSelectAll([FromQuery] FilterBase filterBase)
        {
            try
            {
                return await _mediator.Send(new GetAllEmployeerQuery { Filters = filterBase });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{register}")]
        public async Task<EmployeerViewModel> GetSelectOneAsync([FromRoute] long register)
        {
            return await _mediator.Send(new GetOneEmployeerQuery { Register = register });
        }

        [HttpPost]
        public async Task<IActionResult> PostEmployeerAsync([FromBody] PersistEmployeerCommand persistEmployeerCommand)
        {
            if (persistEmployeerCommand == null)

                return BadRequest();

            var response = await _mediator.Send(persistEmployeerCommand);
            var absolutePath = string.Format("{0}://{1}{2}", Request.Scheme, Request.Host, Request.Path.Value);
            return Created(new Uri(absolutePath + "/" + response.Register), response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] PersistEmployeerCommand persistEmployeerCommand)
        {
            if (persistEmployeerCommand == null)

                return BadRequest();

            return Ok(await _mediator.Send(persistEmployeerCommand));
        }

        [HttpDelete]
        [Route("{register}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] long register)
        {
            if (register == 0)

                return NotFound();

            await _mediator.Send(new DeleteOneEmployeerCommand { Register = register });

            return NoContent();
        }
    }
}
