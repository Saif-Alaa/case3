using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolCaseStudy.Dtos;
using SchoolCaseStudy.Models;
using SchoolCaseStudy.Work;

namespace SchoolCaseStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        protected readonly IUnitOfWork unitOfWork;
        protected readonly IMapper mapper;

        public CourseController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Getall()
        {
            var data = await unitOfWork.Cousrces.GetAll();


            var r = mapper.Map<List<CourseDtos>>(data);
            return Ok(r);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CourseCreateDtos courseCreateDtos)
        {

            var r = mapper.Map<Course>(courseCreateDtos);

            unitOfWork.Cousrces.Add(r);
            unitOfWork.Save();

            return Created();
        }
        [HttpPut]
        public async Task<IActionResult> PutStudent(int id, CourseCreateDtos teacher)
        {
            var data = await unitOfWork.Cousrces.GetById(id);
            if (data == null)
            {
                return NotFound();
            }

            mapper.Map(teacher, data);
            unitOfWork.Cousrces.Update(data);
            unitOfWork.Save();
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTeacher(int id)
        {

            var data = await unitOfWork.Cousrces.GetById(id);
            if (data == null)
            {
                return NotFound();
            }
            unitOfWork.Cousrces.Delete(id);
            unitOfWork.Save();
            return NoContent();
        }

        [HttpGet("GetCourseTitle")]
        public async Task<IActionResult> GetCourseTitle(string name)
        {
            var c = await unitOfWork.Cousrces.GetAll();

            var filter = c.Where(e => e.Title.Contains(name))
            .ToList();

            if (filter == null) { return BadRequest("Not Found"); }
            var r = mapper.Map<List<CourseDtos>>(filter);
            return Ok(r);

        }


        [HttpGet("GetCoursecreadhours")]
        public async Task<IActionResult> GetCoursecreadhours(int id , decimal hours)
        {
            var data = await unitOfWork.Cousrces.Coursewithhours();

            var filter = data.Where(e => e.TeacherId == id && e.CreditHours <= hours)
                .Select(d => new 
                {
                    Id = d.Id,
                    Title = d.Title,
                    TeacherId = d.TeacherId,
                    CreditHours = hours
                })
                .ToList();
            return Ok(filter);

        }


        [HttpGet("Id")]

        public async Task<IActionResult> Coursehasstudent(int id)
        {
            var data = await unitOfWork.Cousrces.GetById(id);
            if (data == null) return NotFound();
            var s = "";
           

            if (data.enrollments.Count == 0)
            {
                s = "Course hasn't students";
            }
            else 
            {
                s = "Course has students" +
                    "CourseId :" + data.Id + "\n" +
                    "Course Name : " + data.Title + "\n" +
                    "Students Count" + data.enrollments.Count;
                
           
            }
            return Ok(s);

        }
    }
}
