using Microsoft.AspNetCore.Mvc;
using Student.Services.Interfaces;
using Students.Model;

namespace AddBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        
        //NewStudent
        [HttpPost("AddStudent")]
        public async Task<ActionResult<Students.Model.Student>> AddStudent([FromBody] Students.Model.Student student)
        {
            if (student == null)
            {
                return BadRequest("Invalid student data.");
            }

            var newStudent = await _studentService.AddStudent(student);
            return CreatedAtAction(nameof(GetStudentByStudentNumber), new { studentNumber = newStudent.StudentNumber }, newStudent);

        }

        //GetByStudentNumber
        [HttpGet("Student/{studentNumber}")]
        public async Task<ActionResult<Students.Model.Student>> GetStudentByStudentNumber(int studentNumber)
        {
            var student = await _studentService.GetStudentByNumber(studentNumber);
            return Ok(student);
        }

        //GetByDepartment
        [HttpGet("Departments/{department}")]
        public async Task<ActionResult<List<Students.Model.Student>>> GetStudentByDepartment(string department)
        {
            var students = await _studentService.GetStudentByDepartment(department);
            return Ok(students);
        }

        //GetByYear
        [HttpGet("Years/{year}")]
        public async Task<ActionResult<List<Students.Model.Student>>> GetStudentByYear(int year)
        {
            var students = await _studentService.GetStudentByYear(year);
            return Ok(students);
        }


        //Update
        [HttpPut("UpdateStudent")]
        public async Task<ActionResult<Students.Model.Student>> UpdateStudent([FromBody] Students.Model.Student  student)
        {
            var updatedStudent = await _studentService.UpdateStudent(student);
            return NoContent();
        }

        //Delete
        [HttpDelete("DeleteStudent/{studentNumber}")]
        public async Task<ActionResult> DeleteStudent(int studentNumber)
        {
            var isDeleted = await _studentService.DeleteStudent(studentNumber);
            if (isDeleted)
            {
                return Ok($"Student with number {studentNumber} has been deleted.");
            }

            return NotFound($"Student with number {studentNumber} was not found.");
        }
    }
}
