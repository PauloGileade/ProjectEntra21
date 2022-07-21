using Microsoft.AspNetCore.Mvc;
using ProjectEntra21.Services;
using ProjectEntra21.Domain.Entiteis;

namespace ProjectEntra21.Controllers
{
    public class EmployeerController : ControllerBase
    {
        private IEmployeerService _employeerService;

        public EmployeerController(IEmployeerService employeerService)
        {
            _employeerService = employeerService;
        }

        [HttpGet]
        public IActionResult get()
        {
            return Ok(_employeerService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var employeer = _employeerService.FindById(id);
            if (employeer == null)
            {
                return NotFound();
            }

            return Ok(employeer);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Employeer employeer)
        {
            if (employeer == null)
            {
                return BadRequest();
            }

            return Ok(_employeerService.Create(employeer));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Employeer employeer)
        {
            if (employeer == null)
            {
                return BadRequest();
            }

            return Ok(_employeerService.Update(employeer));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _employeerService.Delete(id);
            return NoContent();
        }
    }
}
