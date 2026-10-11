using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolCaseStudy.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required , Range(3 , 100)]
        public string Title { get; set; }
        [Required, Range(1 , 6)]

        public int CreditHours { get; set; }

        [ForeignKey("Teacher")]
        public int TeacherId { get; set; }
        public Teacher Teacher  { get; set; }

        public List<Enrollment> enrollments { get; set; } = new List<Enrollment> { };

    }

}
