using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectEntra21.src.Application.Query.TotalPartials;
using ProjectEntra21.src.Application.ViewModels;
using ProjectEntra21.src.Domain.Enums;
using System;
using System.Threading.Tasks;

namespace ProjectEntra21.src.Presentation.Controllers
{
    public class TotalPartialsController : Entra21Controller
    {
        public TotalPartialsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("{phase}/{codeCell}")]
        public async Task<ActionResult<TotalPartialViewModel>> GetSelectOneAsync([FromRoute] PhaseCell phase, long codeCell)
        {
            try
            {
                return await _mediator.Send(new GetOneTotalPartialQuery { Phase = phase, CodeCell = codeCell});

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
