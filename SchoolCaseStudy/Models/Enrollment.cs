using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolCaseStudy.Models
{
    public class Enrollment
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        [ForeignKey("course")]

        public int CourseId { get; set; }
        [Required]
        public DateTime EnrollmentDate { get; set; }
        [Range(0 , 100)]
        public decimal? Grade { get; set; }

        public Student Student { get; set; }
        public Course course { get; set; }
    }
}
