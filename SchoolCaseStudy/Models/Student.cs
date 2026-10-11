using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SchoolCaseStudy.Models
{
    [Index(nameof(Email) , IsUnique = true)]
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(3),MaxLength(100)]
        public string FullName { get; set; }
        [Required , EmailAddress]
        public string Email { get; set; }
        [Required , Phone]
        public string Phone { get; set; }
        [Required]
        public DateTime DirthDate { get; set; }
        [Required]

        public string Gender { get; set; }

        public StudentProfile StudentProfile  { get; set; }
        public List<Enrollment> enrollments { get; set; } = new List<Enrollment> { };

    }
}
