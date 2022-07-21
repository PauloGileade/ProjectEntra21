using Microsoft.AspNetCore.Mvc;
using ProjectEntra21.Domain.Entiteis;
using ProjectEntra21.Infrastructure.Database.Common;

namespace ProjectEntra21.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeerController : ControllerBase
    {
        private IEmployeerRepository _employeerRepository;

        public EmployeerController(IEmployeerRepository employeerRepository)
        {
            _employeerRepository = employeerRepository;
        }

        /*[HttpGet]
        public IActionResult get()
        {
            return Ok(_employeerRepository.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var employeer = _employeerRepository.FindById(id));
            if (employeer == null)
            {
                return NotFound();
            }

            return Ok(employeer);
        }
        */

        [HttpPost]
        public IActionResult Post([FromBody] Employeer employeer)
        {
            if (employeer == null)
            {
                return BadRequest();
            }

            return Ok(_employeerRepository.InsertOrUpdate(employeer));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Employeer employeer)
        {
            if (employeer == null)
            {
                return BadRequest();
            }

            return Ok(_employeerRepository.Update(employeer));
        }
        /*
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _employeerRepository.Delete(id);
            return NoContent();
        }
        */
    }
}
