using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Talent
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Title { get; set; }

    [Required]
    public string Description { get; set; }

    public string? VideoUrl { get; set; }

    [Required]
    public string Category { get; set; }

    [Required]

    public string UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public IdentityUser? User { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
