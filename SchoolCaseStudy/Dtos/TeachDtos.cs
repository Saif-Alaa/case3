using System.ComponentModel.DataAnnotations;

namespace SchoolCaseStudy.Dtos
{
    public class TeachDtos
    {
        public int Id { get; set; }
     
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime HireDate { get; set; }
    }
    public class TeachCreateDtos
    {

        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime HireDate { get; set; }
    }
}
