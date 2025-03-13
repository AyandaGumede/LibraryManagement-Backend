using System;
using System.ComponentModel.DataAnnotations;

namespace AllBooks.Model { 
public class AllBooks
{
    [Key]
    [Required]
    [MaxLength(20)] 
    public required string Isbn { get; set; } //PK

    [Required]
    [MaxLength(50)]
    public required string Title { get; set; }

    [Required]
    [MaxLength(50)]
    public required string Author { get; set; }
    
    [Required]
    public required string Department { get; set; }

    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "Quantity cannot be negative")]
    public int Quantity { get; set; }
}
}