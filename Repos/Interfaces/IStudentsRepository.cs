using Students.Model;
namespace Student.Repo.Interfaces
{
    public interface IStudentRepository
    {
        Task<Students.Model.Student> AddStudent(Students.Model.Student student);
        Task<Students.Model.Student> GetStudentByNumber(int studentNumber);
        Task<List<Students.Model.Student>> GetStudentByYear(int year);
        Task<List<Students.Model.Student>> GetStudentByDepartment(string department);
        Task<Students.Model.Student> UpdateStudent(Students.Model.Student student);
        Task<bool> DeleteStudent(int studentNumber);
    }
}
