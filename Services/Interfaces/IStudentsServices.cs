using System.Collections.Generic;
using System.Threading.Tasks;
using Students.Model;

namespace Student.Services.Interfaces
{
    public interface IStudentService
    {
        Task<Students.Model.Student> AddStudent(Students.Model.Student student);
        Task<List<Students.Model.Student>> GetStudentByYear(int year);
        Task<Students.Model.Student> GetStudentByNumber(int studentNumber); 
        Task<List<Students.Model.Student>> GetStudentByDepartment(string department);
        Task<Students.Model.Student> UpdateStudent(Students.Model.Student student);
        Task<bool> DeleteStudent(int studentNumber);
    }
}
