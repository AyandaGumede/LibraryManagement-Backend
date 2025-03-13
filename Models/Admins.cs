using System;
using System.ComponentModel.DataAnnotations;

namespace Admins.Model 
{
    public class Administrator
    {
        [Key]
        [Required]
        public int Id { get; set; } //PK

        [Required, EmailAddress]
        [MaxLength(255)]
        public required string Email { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required string Surname { get; set; }

        [Required]
        public required string Campus { get; set; }

        [Required]
        public required string Password { get; set; }
    }

    public class AdminLoginRequest
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }

    public class AdminForgotPass
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
