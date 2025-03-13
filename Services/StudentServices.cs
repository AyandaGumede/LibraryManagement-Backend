using Student.Services.Interfaces;
using Students.Model;
using Student.Repo.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Students.Services
{
    public class StudentService : IStudentService  
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Students.Model.Student> AddStudent(Students.Model.Student student)
        {
            return await _studentRepository.AddStudent(student);
        }

        public async Task<Students.Model.Student> GetStudentByNumber(int studentNumber) 
        {
            return await _studentRepository.GetStudentByNumber(studentNumber);
        }

        public async Task<List<Students.Model.Student>> GetStudentByYear(int year)
        {
            return await _studentRepository.GetStudentByYear(year);
        }

        public async Task<List<Students.Model.Student>> GetStudentByDepartment(string department)
        {
            return await _studentRepository.GetStudentByDepartment(department);
        }

        public async Task<Students.Model.Student> UpdateStudent(Students.Model.Student student)
        {
            return await _studentRepository.UpdateStudent(student);
        }

        public async Task<bool> DeleteStudent(int studentNumber)
        {
            return await _studentRepository.DeleteStudent(studentNumber);
        }
    }
}
