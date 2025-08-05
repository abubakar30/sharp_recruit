namespace sharp_recruit.DTO
{
    public class JobApplicationDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Gender { get; set; }
        public IFormFile Resume { get; set; }
    }
}
