using Microsoft.AspNetCore.Mvc;
using ProjectEntra21.Domain.Entiteis;
using ProjectEntra21.Infrastructure.Database.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectEntra21.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CellEmployeersController : ControllerBase
    {
        private readonly ICellEmployeerRepository _cellEmployeerRepository;

        public CellEmployeersController(ICellEmployeerRepository cellEmployeerRepository)
        {
            _cellEmployeerRepository = cellEmployeerRepository;
        }

        [HttpGet]
        public async Task<IList<CellEmployeer>> GetSelectMore()
        {
            return await _cellEmployeerRepository.SelectMore();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSelectOne([FromRoute] long id)
        {
            var cellEmployeerSelectOne = await _cellEmployeerRepository.SelectOne(x => x.Id == id);
            return Ok(cellEmployeerSelectOne);
        }

        [HttpPost]
        public async Task<IActionResult> PostCellEmployeer([FromBody] CellEmployeer cellEmployeer)
        {
            if(cellEmployeer == null)
                return BadRequest();

            await _cellEmployeerRepository.Insert(cellEmployeer);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CellEmployeer cellEmployeer)
        {
            await _cellEmployeerRepository.Update(cellEmployeer);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var cellEmployeerDelete = await _cellEmployeerRepository.SelectOne(x => x.Id == id);

            if(cellEmployeerDelete != null)
            {
                await _cellEmployeerRepository.Delete(cellEmployeerDelete);
                return Ok();
            }

            return NoContent();
        }
    }
}
