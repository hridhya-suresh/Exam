using Exam.Data;
using Exam.Models.Dto;
using Exam.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Exam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public StudentController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;

        }
        [HttpGet]
        public IActionResult GetAllStudent()
        {
            var allStudents = dbContext.Students.ToList();
            return Ok(allStudents);
        }

        [HttpPost ("AddStudent")]

        public IActionResult AddStudent (AddStudentDto addStudentDto)
        {
            var studentEntity = new Student()
            {
                Name = addStudentDto.StudentName,
                Email = addStudentDto.StudentEmail
            };

            dbContext.Students.Add(studentEntity);
            dbContext.SaveChanges();
            return Ok(studentEntity);
        }

    }
}
