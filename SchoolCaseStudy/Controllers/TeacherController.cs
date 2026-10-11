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
    public class TeacherController : ControllerBase
    {
        protected readonly IUnitOfWork unitOfWork;
        protected readonly IMapper mapper;

        public TeacherController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Getall() 
        {
            var data = await unitOfWork.Teacher.GetAll();


            var r = mapper.Map<List<TeachDtos>>(data);
            return Ok(r);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TeachCreateDtos teachCreateDtos)
        {

            var r = mapper.Map<Teacher>(teachCreateDtos);

            unitOfWork.Teacher.Add(r);
            unitOfWork.Save();

            return Created();
        }

        [HttpPut]
        public async Task<IActionResult> PutStudent(int id, TeachCreateDtos teacher)
        {
            var data = await unitOfWork.Teacher.GetById(id);
            if (data == null)
            {
                return NotFound();
            }

            mapper.Map(teacher, data);
            unitOfWork.Teacher.Update(data);
            unitOfWork.Save();
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTeacher(int id)
        {

            var data = await unitOfWork.Teacher.GetById(id);
            if (data == null)
            {
                return NotFound();
            }
            unitOfWork.Teacher.Delete(id);
            unitOfWork.Save();
            return NoContent();
        }


    }
}
