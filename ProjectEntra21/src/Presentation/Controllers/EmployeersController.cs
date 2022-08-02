using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectEntra21.src.Application.Query.Employeers;
using ProjectEntra21.src.Application.Request.Employeers;
using ProjectEntra21.src.Application.ViewModels;
using ProjectEntra21.src.Domain.Common;
using System;
using System.Threading.Tasks;

namespace ProjectEntra21.src.Presentation.Controllers
{
    public class EmployeersController : Entra21Controller
    {
        public EmployeersController(IMediator mediator) : base(mediator)
        {
        }
        /*
           [HttpGet("qrcode")]
        public IActionResult GetQrCode()
        {
            var image = QrCodeGenerator.GenerateByteArray("https://balta.io");
            return File(image, "image/jpeg");
        }
        */

        [HttpGet]
        public async Task<ActionResult<PaginationResponse<GetEmployeerViewModel>>> GetSelectMore([FromQuery] FilterBase filterBase)
        {
            try
            {
                var result = await _mediator.Send(new GetAllEmployeerQuery {Filters = filterBase });
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{register}")]
        public async Task<GetEmployeerViewModel> GetSelectOneAsync([FromRoute] long register)
        {
            return await _mediator.Send(new GetOneEmployeerRequest { Register = register });
        }

        [HttpPost]
        public async Task<IActionResult> PostEmployeerAsync([FromBody] PersistEmployeerRequest persistEmployeerRequest)
        {
            if (persistEmployeerRequest == null)

                return BadRequest();

            var response = await _mediator.Send(persistEmployeerRequest);
            var absolutePath = string.Format("{0}://{1}{2}", Request.Scheme, Request.Host, Request.Path.Value);
            return Created(new Uri(absolutePath + "/" + response.Register), response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] PersistEmployeerRequest persistEmployeerRequest)
        {
            if (persistEmployeerRequest == null)

                return BadRequest();

            return Ok(await _mediator.Send(persistEmployeerRequest));
        }

        [HttpDelete]
        [Route("{register}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] long register)
        {
            await _mediator.Send(new DeleteOneEmployeerRequest { Register = register });

            return NoContent();
        }
    }
}
