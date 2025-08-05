using Microsoft.AspNetCore.Mvc;
using sharp_recruit.Data;
using sharp_recruit.Models;
using sharp_recruit.DTO;

namespace sharp_recruit.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobApplicationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JobApplicationController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("get_job_application")]
        public IActionResult GetJobApplications()
        {
            var applications = _context.JobApplications.ToList();
            return Ok(applications);
        }

        [HttpPost("create")]
        // [Consumes("multipart/form-data")]
        public async Task<IActionResult> CreateJobApplication([FromForm] JobApplicationDto application)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            string savedPath = null;

            if (application.Resume != null)
            {
                // Ensure Uploads directory exists
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);

                // Create a unique file name
                var uniqueFileName = $"{Guid.NewGuid()}_{application.Resume.FileName}";
                var fullPath = Path.Combine(uploadsFolder, uniqueFileName);

                // Save the file
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await application.Resume.CopyToAsync(stream);
                }

                // Save relative path to database (e.g. "uploads/abc.pdf")
                savedPath = Path.Combine("uploads", uniqueFileName).Replace("\\", "/");
            }

            // Map DTO to entity
            var jobApp = new JobApplication
            {
                FullName = application.FullName,
                Email = application.Email,
                Phone = application.Phone,
                Gender = application.Gender,
                Resume = savedPath
            };

            _context.JobApplications.Add(jobApp);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(CreateJobApplication), new { id = jobApp.Id }, jobApp);
        }

    }
}
