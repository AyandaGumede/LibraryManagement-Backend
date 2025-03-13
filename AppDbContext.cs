using System;
using Microsoft.EntityFrameworkCore;
using Admins.Model;
using Borrowing.Model;
using Students.Model;
using AllBooks.Model;
using System.Reflection.Emit;

namespace AppDbContext.Namespace
{
    public class AppDbContext : DbContext
    {
       
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
            public DbSet<Students.Model.Student> Students
            {
                get;
                set;
            }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Students.Model.Student>().HasKey(s => s.StudentNumber);

            modelBuilder.Entity<Borrowing.Model.BorrowingRecord>()
                .HasOne(b => b.Student)    
                .WithMany(static s => s.BorrowingRecords)
                .HasForeignKey(b => b.StudentNumber);

            modelBuilder.Entity<Borrowing.Model.BorrowingRecord>()
                .HasOne(b => b.Book)
                .WithMany()
                .HasForeignKey(b => b.Isbn);
        }


        public DbSet<Admins.Model.Administrator> Admins { get; set; } = null!;

            public DbSet<Borrowing.Model.BorrowingRecord> BorrowingRecords { get; set; } = null!;
            
            public DbSet<AllBooks.Model.AllBooks> AllBooks { get; set; } = null!;
        
        
    }
}
