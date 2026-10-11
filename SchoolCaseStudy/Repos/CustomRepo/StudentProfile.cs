using SchoolCaseStudy.Data;
using SchoolCaseStudy.GanaricRepos;
using SchoolCaseStudy.Models;
using SchoolCaseStudy.Repos.InterFaces;

namespace SchoolCaseStudy.Repos.CustomRepo
{
    public class StudentProfilerepo : GanaricRepo<StudentProfile>, IStudentProfile
    {
        public StudentProfilerepo(AppDbContext appDbContext) : base(appDbContext)
        {
        }

 
    }
}
