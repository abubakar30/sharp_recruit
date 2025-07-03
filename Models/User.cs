using System.ComponentModel.DataAnnotations;

public class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string PasswordHash { get; set; } // Store hashed password

    public string Role { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }
}
