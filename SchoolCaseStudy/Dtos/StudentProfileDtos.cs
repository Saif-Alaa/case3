using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SchoolCaseStudy.Dtos
{
    public class StudentProfileDtos
    {
        public int Id { get; set; }
        
        public string Address { get; set; }
        
        public string ParentPhone { get; set; }
       

        public string EmergencyContact { get; set; }

       
        public int StudentId { get; set; }
    }
    public class StudentProfileCreateDtos
    {

        public string Address { get; set; }

        public string ParentPhone { get; set; }


        public string EmergencyContact { get; set; }


        public int StudentId { get; set; }
    }
}
