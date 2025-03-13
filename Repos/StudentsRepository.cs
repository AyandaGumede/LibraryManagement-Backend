using Microsoft.EntityFrameworkCore;
using Student.Repo.Interfaces;
using Students.Model;
using AppDbContext.Namespace;

namespace Student.Repos
{
    public class StudentsRepository : IStudentRepository
    {
        private readonly AppDbContext.Namespace.AppDbContext _context;

        public StudentsRepository(AppDbContext.Namespace.AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        // ADDING A STUDENT
        public async Task<Students.Model.Student> AddStudent(Students.Model.Student student)
        {
            if (await _context.Students.AnyAsync(s => s.StudentNumber == student.StudentNumber))
            {
                throw new InvalidOperationException($"A student with StudentNumber {student.StudentNumber} already exists.");
            }

            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return student;
        }

        // FETCHING STUDENT BY NUMBER
        public async Task<Students.Model.Student> GetStudentByNumber(int studentNumber)
        {
            var student = await _context.Students.FindAsync(studentNumber);
            return student ?? throw new KeyNotFoundException($"Student with StudentNumber {studentNumber} not found.");
        }

        // FETCHING STUDENTS BY DEPARTMENT
        public async Task<List<Students.Model.Student>> GetStudentsByDepartment(string department)
        {
            var students = await _context.Students
                .Where(s => s.Qualification == department)
                .AsNoTracking()
                .ToListAsync();

            return students.Any() ? students :
                throw new KeyNotFoundException($"No students found in the '{department}' department.");
        }

        // FETCHING STUDENTS BY YEAR
        public async Task<List<Students.Model.Student>> GetStudentsByYear(int year)
        {
            var students = await _context.Students
                .Where(s => s.Year == year)
                .AsNoTracking()
                .ToListAsync();

            return students.Any() ? students :
                throw new KeyNotFoundException($"No students found for the year {year}.");
        }

        // UPDATING A STUDENT
        public async Task<Students.Model.Student> UpdateStudent(Students.Model.Student student)
        {
            var existingStudent = await _context.Students.FindAsync(student.StudentNumber);
            if (existingStudent == null)
            {
                throw new KeyNotFoundException($"Student with StudentNumber {student.StudentNumber} not found.");
            }

            // Updating fields
            _context.Entry(existingStudent).CurrentValues.SetValues(student);
            await _context.SaveChangesAsync();
            return existingStudent;
        }

        // DELETING A STUDENT
        public async ValueTask<bool> DeleteStudent(int studentNumber)
        {
            var student = await _context.Students.FindAsync(studentNumber);
            if (student == null)
            {
                throw new KeyNotFoundException($"Student with StudentNumber {studentNumber} not found.");
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return true;
        }

        public Task<List<Students.Model.Student>> GetStudentByYear(int year)
        {
            throw new NotImplementedException();
        }

        public Task<List<Students.Model.Student>> GetStudentByDepartment(string department)
        {
            throw new NotImplementedException();
        }

        Task<bool> IStudentRepository.DeleteStudent(int studentNumber)
        {
            throw new NotImplementedException();
        }
    }
}
