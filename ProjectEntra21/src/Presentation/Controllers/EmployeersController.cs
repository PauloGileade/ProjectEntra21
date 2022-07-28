using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectEntra21.src.Application.Request.Employeers;
using ProjectEntra21.src.Application.Request.Employeers.ViewModels;
using ProjectEntra21.src.Domain.Entiteis;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectEntra21.Controllers
{
    public class EmployeersController : Entra21Controller
    {
        public EmployeersController(IMediator mediator) : base(mediator)
        {
        }
        /*
        [HttpGet]
        public async Task<IActionResult> GetSelectMore([FromQuery] )
        {   
            var result =  await _mediator.Send(Request.Query);
            return Ok(result);
        }
        */
        [HttpGet]
        [Route("{register}")]
        public async Task<GetOneEmployeerViewModel> GetSelectOne([FromRoute] long register)
        {
            return await _mediator.Send(new GetOneEmployeerRequest { Register = register });
        }
        
        [HttpPost]
        public async Task<IActionResult> PostEmployeer([FromBody] PersistEmployeerRequest persistEmployeerRequest)
        {
            if (persistEmployeerRequest == null)

                return BadRequest();

            var response = await _mediator.Send(persistEmployeerRequest);
            var absolutePath = String.Format("{0}://{1}{2}", Request.Scheme, Request.Host, Request.Path.Value);
            return Created(new Uri(absolutePath + "/" + response.Register), response);
        }
        
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PersistEmployeerRequest persistEmployeerRequest)
        {   
            if(persistEmployeerRequest == null)

                return BadRequest();

            return Ok(await _mediator.Send(persistEmployeerRequest));
        }
        
        [HttpDelete]
        [Route("{register}")]
        public async Task<IActionResult> Delete([FromRoute] long register)
        {
            await _mediator.Send(new DeleteOneEmployeerRequest { Register = register });

            return NoContent();
        }
    }
}
