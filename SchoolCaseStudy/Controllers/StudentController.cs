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
    public class StudentController : ControllerBase
    {
        protected readonly IUnitOfWork unitOfWork;
        protected readonly IMapper mapper;

        public StudentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentCreateDtos studentCreateDtos)
        {
            var student = await unitOfWork.Student.GetAll();

            var checkemail = student.Where(e => e.Email == studentCreateDtos.Email)
                .FirstOrDefault();

            if (checkemail != null) { return BadRequest("Email Must Be unique"); }

            var r = mapper.Map<Student>(studentCreateDtos);

            unitOfWork.Student.Add(r);
            unitOfWork.Save();

            return Created();
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Gat()
        {
            var data = await unitOfWork.Student.GetAll();
            var r = mapper.Map<List<StudentDtos>>(data);
            return Ok(r);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GatByid(int id)
        {
            var data = await unitOfWork.Student.GetById(id);

            if (data != null)
            {
                var r = mapper.Map<StudentDtos>(data);
                return Ok(r);
            }
            return NotFound();
        }


        [HttpPut]
        public async Task<IActionResult> PutStudent(int id , StudentCreateDtos student)
        {
            var data = await unitOfWork.Student.GetById(id);
            if (data == null) 
            {
                return NotFound();
            }

            mapper.Map(student,data);
            unitOfWork.Student.Update(data);
            unitOfWork.Save();
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteStudent(int id)
        {

            var data = await unitOfWork.Student.GetById(id);
            if (data == null)
            {
                return NotFound();
            }
            unitOfWork.Student.Delete(id);
            unitOfWork.Save();
            return NoContent();
        }


        [HttpGet("Getstudentwithname")]
        public async Task<IActionResult> GetStudentswithName(string name)
        {
           var student = await unitOfWork.Student.GetAll();

            var filter = student.Where(e => e.FullName.Contains(name))
            .ToList();

            if (filter == null) { return BadRequest("Not Found"); }
            var r = mapper.Map<List<StudentDtos>>(filter);
            return Ok(r);

        }

        [HttpGet("GetstudentwithGender")]
        public async Task<IActionResult> GetStudentswithgender(string gender)
        {
            var student = await unitOfWork.Student.GetAll();

            var filter = student.Where(e => e.Gender.Contains(gender))
            .ToList();

            var r = mapper.Map<List<StudentDtos>>(filter);
            return Ok(r);

        }


        [HttpGet("PageSize")]
        public async Task<IActionResult> PageSize(int number , int size)
        {
            var student = await unitOfWork.Student.GetAll();

            var filter = student.Skip((number - 1) * size).Take(size).ToList();
     

            var r = mapper.Map<List<StudentDtos>>(filter);
            return Ok(r);

        }
    }
}
