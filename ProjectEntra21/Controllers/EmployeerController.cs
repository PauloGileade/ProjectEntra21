using Microsoft.AspNetCore.Mvc;
using ProjectEntra21.Domain.Entiteis;
using ProjectEntra21.Infrastructure.Database.Common;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

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

        [HttpGet]
        public async Task<IList<Employeer>> GetSelectMore()
        {
            return await _employeerRepository.SelectMore();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSelectOne([FromRoute] long id)
        {
            var employeerSelectOne = await _employeerRepository.SelectOne(x => x.Id == id);
            return Ok(employeerSelectOne);
        }

        [HttpPost]
        public async Task<IActionResult> PostEmployeer([FromBody] Employeer employeer)
        {
            if (employeer == null)

                return BadRequest();


            await _employeerRepository.InsertOrUpdate(employeer);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Employeer employeer)
        {
            await _employeerRepository.Update(employeer);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var employeerDelete = await _employeerRepository.SelectOne(x => x.Id == id);

            if (employeerDelete != null)
            {
                await _employeerRepository.Delete(employeerDelete);
                return Ok();
            }

            return NoContent();
        }
    }
}
