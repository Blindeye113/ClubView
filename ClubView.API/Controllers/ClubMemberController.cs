using Microsoft.AspNetCore.Mvc;
using ClubView.API.Interfaces;
using ClubView.API.Models;

namespace ClubView.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClubMemberController : ControllerBase
    {
        private readonly IClubMemberRepository _clubMemberRepository;

        public ClubMemberController(IClubMemberRepository clubMemberRepository)
        {
            _clubMemberRepository = clubMemberRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClubMember>> Get(int id)
        {
            var member = await _clubMemberRepository.GetByIdAsync(id);

            if (member == null)
            {
                return NotFound();
            }

            return Ok(member);
        }

        [HttpGet]
        public async Task<ActionResult<List<ClubMember>>> GetAll()
        {
            var members = await _clubMemberRepository.GetAllAsync();

            if (members == null || members.Count == 0)
            {
                return NotFound();
            }

            return Ok(members);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] ClubMember member)
        {
            await _clubMemberRepository.AddAsync(member);

            return CreatedAtAction(nameof(Get), new { id = member.Id }, member);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] ClubMember member)
        {
            if (id != member.Id)
            {
                return BadRequest();
            }

            await _clubMemberRepository.UpdateAsync(member);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _clubMemberRepository.DeleteAsync(id);

            return NoContent();
        }
    }
}
