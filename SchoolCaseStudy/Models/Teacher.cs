using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SchoolCaseStudy.Models
{
    [Index(nameof(Email), IsUnique = true)]

    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Range(3, 100)]
        public string FullName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, Phone]
        public string Phone { get; set; }
        [Required]
        public DateTime HireDate { get; set; }
        public List<Course> courses { get; set; } = new List<Course> { };

    }
}
