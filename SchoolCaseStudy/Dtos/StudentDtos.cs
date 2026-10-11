using System.ComponentModel.DataAnnotations;

namespace SchoolCaseStudy.Dtos
{
    public class StudentDtos
    {
        public int Id { get; set; }
 
        public string FullName { get; set; }
        public string Email { get; set; }
        
        public string Phone { get; set; }
        
        public DateTime DirthDate { get; set; }
       

        public string Gender { get; set; }

    }

    public class StudentCreateDtos
    {

        public string FullName { get; set; }
        public string Email { get; set; }

        public string Phone { get; set; }

        public DateTime DirthDate { get; set; }


        public string Gender { get; set; }

    }
}
