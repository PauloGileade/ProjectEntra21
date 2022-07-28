using Microsoft.AspNetCore.Mvc;
using ProjectEntra21.src.Application.Database;
using ProjectEntra21.src.Domain.Entiteis;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectEntra21.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CellsController : ControllerBase
    {
        private readonly ICellRepository _cellRepository;

        public CellsController(ICellRepository cellRepository)
        {
            _cellRepository = cellRepository;
        }

        [HttpGet]
        public async Task<IList<Cell>> GetSelectMore()
        {
            return await _cellRepository.SelectMore();
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetSelectOne([FromRoute] int code)
        {
            var cellSelectOne = await _cellRepository.SelectOne(x => x.CodeCell == code);
            return Ok(cellSelectOne);
        }

        [HttpPost]
        public async Task<IActionResult> PostCell([FromBody] Cell cell)
        {
            if (cell == null)

                return BadRequest();


            await _cellRepository.Insert(cell);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Cell cell)
        {
            await _cellRepository.Update(cell);
            return NoContent();
        }

        [HttpDelete("{code}")]
        public async Task<IActionResult> Delete(int code)
        {
            var cellDelete = await _cellRepository.SelectOne(x => x.CodeCell == code);

            if (cellDelete != null)
            {
                await _cellRepository.Delete(cellDelete);
                return Ok();
            }

            return NoContent();
        }
    }
}
