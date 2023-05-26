using Microsoft.AspNetCore.Mvc;
using ClubView.API.Models;
using ClubView.API.Interfaces;

namespace ClubView.API.Handlers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WhiskeyController : ControllerBase
    {
        private readonly IWhiskeyRepository _whiskeyRepository;

        public WhiskeyController(IWhiskeyRepository whiskeyRepository)
        {
            _whiskeyRepository = whiskeyRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Whiskey>> GetByIdAsync(int id)
        {
            var whiskey = await _whiskeyRepository.GetByIdAsync(id);

            if (whiskey == null)
            {
                return NotFound();
            }

            return whiskey;
        }

        [HttpGet]
        public async Task<ActionResult<List<Whiskey>>> GetAllAsync()
        {
            var whiskeys = await _whiskeyRepository.GetAllAsync();

            return whiskeys;
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync(Whiskey whiskey)
        {
            await _whiskeyRepository.AddAsync(whiskey);

            return CreatedAtAction(nameof(GetByIdAsync), new { id = whiskey.Id }, whiskey);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id, Whiskey whiskey)
        {
            if (id != whiskey.Id)
            {
                return BadRequest();
            }

            await _whiskeyRepository.UpdateAsync(whiskey);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _whiskeyRepository.DeleteAsync(id);

            return NoContent();
        }

    }
}
