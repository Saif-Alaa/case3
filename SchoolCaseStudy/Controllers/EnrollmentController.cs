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
    public class EnrollmentController : ControllerBase
    {
        protected readonly IUnitOfWork unitOfWork;
        protected readonly IMapper mapper;

        public EnrollmentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpPost]

        public async Task<IActionResult> Create(EnrollmentCreateDtos enrollment)
        {
        
            var r = mapper.Map<Enrollment>(enrollment);
            unitOfWork.Enrollment.Add(r);
            unitOfWork.Save();
            return Created();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id) 
        {
            var data = unitOfWork.Enrollment.GetById(id);
            if (data == null) return NotFound();
            unitOfWork.Enrollment.Delete(id);
            unitOfWork.Save();
            return NoContent();
        }

        [HttpGet("GetEnrollmentByStudent")]
        public async Task<IActionResult> GetByStudent(int id)
        {
            var data = await unitOfWork.Enrollment.GetEnrollmentByStudent();

            var filter = data.Where(s => s.StudentId == id)
                .Select(e => new 
                {
                    EnrollmentId = e.Id,
                    EnrollmentDate = e.EnrollmentDate,
                    StudentId = e.StudentId,
                    StudentName = e.Student.FullName,
                }).ToList();

            return Ok(filter);
        }

        [HttpGet("GetEnrollmentByCourse")]
        public async Task<IActionResult> GetByCourse(int id)
        {
            var data = await unitOfWork.Enrollment.GetEnrollmentByCourse();

            var filter = data.Where(s => s.CourseId == id)
                .Select(e => new
                {
                    EnrollmentId = e.Id,
                    EnrollmentDate = e.EnrollmentDate,
                    CourseId = e.CourseId,
                    courseName = e.course.Title,
                }).ToList();

            return Ok(filter);
        }

        [HttpGet("api/reports/course-statistics")]

        public async Task<IActionResult> coursestatistics() 
        {
            var data = await unitOfWork.Enrollment.GetEnrollmentByCourse();

            var filter = data.GroupBy(i => i.CourseId)
                .Select(e => new
                {
                
                    CourseId = e.Key,
                    courseName = e.First().course.Title,
                    TeacherName = e.First().course.Teacher.FullName,
                    StudentsCount = e.Count(),
                }).ToList();

            return Ok(filter);
        }


        [HttpGet("api/reports/average-grades")]
        public async Task<IActionResult> averagegrades()
        {
            var data = await unitOfWork.Enrollment.GetEnrollmentByCourse();

            var f = data.GroupBy(t => t.CourseId)
               .Select(e => new
               {
                   Id = e.Key,
                   CourseTitle = e.First().course.Title,
                   Avg = e.Where(i => i.Grade.HasValue).Average(e => e.Grade)
            
               }).ToList();

            return Ok(f);
        }


        [HttpGet("api/reports/top-students")]
        public async Task<IActionResult> gettopstudent() 
        {
            var data = await unitOfWork.Enrollment.GetEnrollmentByStudent();

            var f = data.OrderByDescending(e => e.Grade)
               .Select(e => new 
               {
                   Id = e.Id,
                   StudentId = e.StudentId,
                   StudentName = e.Student.FullName,
                   Grade = e.Grade
               }).Take(2).ToList();

            return Ok(f);
        }
    }
}
