using System.ComponentModel.DataAnnotations;

namespace HBO.Models;

public class Customer
{
    public int CustomerId { get; set; }
    [Required]
    [StringLength(50)]
    public string FirstName { get; set; } = string.Empty;
    [Required]
    [StringLength(50)]
    public string LastName { get; set; } = string.Empty;
    [Required, StringLength(50)]
    public string Gender { get; set; } = string.Empty;
}
