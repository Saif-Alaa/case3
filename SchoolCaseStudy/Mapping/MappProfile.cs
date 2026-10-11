using AutoMapper;
using SchoolCaseStudy.Dtos;
using SchoolCaseStudy.Models;
using SchoolCaseStudy.Repos.InterFaces;

namespace SchoolCaseStudy.Mapping
{
    public class MappProfile : Profile
    {
        public MappProfile() 
        {
            CreateMap<Student, StudentDtos>();
            CreateMap<StudentCreateDtos, Student>();


            CreateMap<StudentProfile, StudentProfileDtos>();
            CreateMap<StudentProfileCreateDtos, StudentProfile>();



            CreateMap<Teacher, TeachDtos>();
            CreateMap<TeachCreateDtos, Teacher>();

            CreateMap<Course, CourseDtos>();
            CreateMap<CourseCreateDtos, Course>();

            CreateMap<Enrollment, EnrollmentDtos>();
            CreateMap<EnrollmentCreateDtos, Enrollment>();


        }
    }
}
