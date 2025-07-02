using Microsoft.AspNetCore.Mvc;
using sharp_recruit.Data;
using sharp_recruit.Models;

namespace sharp_recruit.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidateController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CandidateController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetCandidates()
        {
            var candidates = _context.Candidates.ToList();
            return Ok(candidates);
        }

        [HttpPost]
        public IActionResult CreateCandidate([FromBody] Candidate candidate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Candidates.Add(candidate);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetCandidates), new { id = candidate.Id }, candidate);
        }

    }
}
