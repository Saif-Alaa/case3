using SchoolCaseStudy.Data;
using SchoolCaseStudy.GanaricRepos;
using SchoolCaseStudy.Models;
using SchoolCaseStudy.Repos.InterFaces;

namespace SchoolCaseStudy.Repos.CustomRepo
{
    public class StudentRepo : GanaricRepo<Student>, IStudent
    {
        public StudentRepo(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
