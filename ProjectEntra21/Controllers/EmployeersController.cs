using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectEntra21.src.Application.Request;
using System;
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
        public async Task<IList<Employeer>> GetSelectMore()
        {
            return await _employeerRepository.SelectMore();
        }

        [HttpGet("{register}")]
        public async Task<IActionResult> GetSelectOne([FromRoute] long register)
        {
            var employeerSelectOne = await _employeerRepository.SelectOne(x => x.Register == register);
            return Ok(employeerSelectOne);
        }
        */
        [HttpPost]
        public async Task<IActionResult> PostEmployeer([FromBody] PersistEmployeerRequest persistEmployeerRequest)
        {
            if (persistEmployeerRequest == null)

                return BadRequest();

            var response = await _mediator.Send(persistEmployeerRequest);
            var absolutePath = String.Format("{0}://{1}{2}", Request.Scheme, Request.Host, Request.Path.Value);
            return Created(new Uri(absolutePath + "/" + response.Register), response);
        }
        /*
        [HttpPut]
        public async Task<IActionResult> Update(Employeer employeer)
        {
            var employeerUpdate = await _employeerRepository.SelectOne(x => x.Register == employeer.Register);

            if (employeerUpdate != null)
            {
                employeerUpdate.Name = employeer.Name;
                employeerUpdate.Document = employeer.Document;
                employeerUpdate.BirthDate = employeer.BirthDate;
                employeerUpdate.Office = employeer.Office;
                employeerUpdate.LevelEmployeer = employeer.LevelEmployeer;
                employeerUpdate.CodeCell = employeer.CodeCell;
                await _employeerRepository.Update(employeerUpdate);
                return NoContent();
            }
            return BadRequest();
        }

        [HttpDelete("{register}")]
        public async Task<IActionResult> Delete(long register)
        {
            var employeerDelete = await _employeerRepository.SelectOne(x => x.Register == register);

            if (employeerDelete != null)
            {
                await _employeerRepository.Delete(employeerDelete);
                return Ok();
            }

            return NoContent();
        }
        */
    }
}
