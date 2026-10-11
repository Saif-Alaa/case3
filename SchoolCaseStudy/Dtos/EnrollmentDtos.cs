using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SchoolCaseStudy.Dtos
{
    public class EnrollmentDtos
    {
        public int Id { get; set; }
        
        public int StudentId { get; set; }

        public int CourseId { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public decimal? Grade { get; set; }

    }
    public class EnrollmentCreateDtos
    {

        public int StudentId { get; set; }

        public int CourseId { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public decimal? Grade { get; set; }

    }
}
