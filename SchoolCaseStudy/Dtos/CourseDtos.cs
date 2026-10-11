using SchoolCaseStudy.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SchoolCaseStudy.Dtos
{
    public class CourseDtos
    {
        public int Id { get; set; }
        public string Title { get; set; }
        

        public int CreditHours { get; set; }

        public int TeacherId { get; set; }

    }
    public class CourseCreateDtos
    {
        public string Title { get; set; }


        public int CreditHours { get; set; }

        public int TeacherId { get; set; }

    }
}
