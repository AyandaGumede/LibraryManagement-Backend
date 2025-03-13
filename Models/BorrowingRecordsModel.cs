using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Students.Model;  // Ensure Student model is included

namespace Borrowing.Model
{
    public class BorrowingRecord
    {
        [Key]
        public int Id { get; set; } 

        [Required]
        [ForeignKey("AllBooks")]
        public required string Isbn { get; set; } 

        public AllBooks.Model.AllBooks? Book { get; set; }

        [Required]
        public int StudentNumber { get; set; } 

        [ForeignKey("StudentNumber")]
        public Students.Model.Student? Student { get; set; }  

        [Required, EmailAddress]
        public required string StudentEmail { get; set; }

        [Required]
        public DateTime BorrowDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        public string Status
        {
            get
            {
                if (ReturnDate.HasValue)
                    return "Returned";

                DateTime dueDate = BorrowDate.AddDays(14);
                return DateTime.Now > dueDate ? "Overdue" : "Borrowed";
            }
        }
    }
}
