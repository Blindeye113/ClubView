using ClubView.API.Interfaces;
using ClubView.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClubView.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClubController : ControllerBase
    {
        private readonly IClubRepository _clubRepository;

        public ClubController(IClubRepository clubRepository)
        {
            _clubRepository = clubRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Club>> GetByIdAsync(int id)
        {
            var club = await _clubRepository.GetByIdAsync(id);
            if (club == null)
            {
                return NotFound();
            }
            return club;
        }

        [HttpGet]
        public async Task<ActionResult<List<Club>>> GetAllAsync()
        {
            var clubs = await _clubRepository.GetAllAsync();
            return clubs;
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync([FromBody] Club club)
        {
            await _clubRepository.AddAsync(club);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] Club club)
        {
            await _clubRepository.UpdateAsync(club);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _clubRepository.DeleteAsync(id);
            return Ok();
        }
    }
}
