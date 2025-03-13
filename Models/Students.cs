using System;
using System.ComponentModel.DataAnnotations;


namespace Students.Model
{
    public class Student
    {

        [Key]
        public int StudentNumber { get; set; }//PK

        [Required, EmailAddress]
        [MaxLength(255)]
        public required string StudentEmail { get; set; }

        [Required]
        [MaxLength(50)]
        public required string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public required string Surname { get; set; }

        [Required]
        [MaxLength(100)]
        public required string Qualification { get; set; }

        [Required]
        [Range(1, 3, ErrorMessage = "Year of study must be between 1 and 3")]
        public int Year { get; set; }

        public ICollection<Borrowing.Model.BorrowingRecord>? BorrowingRecords { get; set; }
    }
}
