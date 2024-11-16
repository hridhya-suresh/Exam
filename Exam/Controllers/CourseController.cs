using Exam.Data;
using Exam.Models.Dto;
using Exam.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public CourseController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;

        }

        [HttpGet("AllCourse")]
        public IActionResult GetAllCourse()
        {
            var allCourse = dbContext.Courses.ToList();
            return Ok(allCourse);
        }

        [HttpPost("AddCourse")]

        public IActionResult AddCourse(AddCourseDto addCourseDto)
        {
            var courseEntity = new Course()
            {
                Title = addCourseDto.Title,
                Description = addCourseDto.Description
            };

            dbContext.Courses.Add(courseEntity);
            dbContext.SaveChanges();
            return Ok(courseEntity);
        }
    }
}
