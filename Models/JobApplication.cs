using System.ComponentModel.DataAnnotations;

namespace sharp_recruit.Models
{
    public class JobApplication
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        public string Phone { get; set; }

        public int Gender { get; set; }

        public string Resume { get; set; }

        public DateTime AppliedAt { get; set; } = DateTime.UtcNow;
    }
}
