using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolCaseStudy.Models
{
    public class StudentProfile
    {
        [Key]
        public int Id { get; set; }
        [Required , MaxLength(200)]
        public string Address { get; set; }
        [Required , Phone]
        public string ParentPhone { get; set; }
        [Required, Phone]

        public string EmergencyContact { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
