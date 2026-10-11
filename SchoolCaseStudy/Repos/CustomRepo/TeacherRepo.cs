using SchoolCaseStudy.Data;
using SchoolCaseStudy.GanaricRepos;
using SchoolCaseStudy.Models;
using SchoolCaseStudy.Repos.InterFaces;

namespace SchoolCaseStudy.Repos.CustomRepo
{
    public class TeacherRepo : GanaricRepo<Teacher>, ITeacher
    {
        public TeacherRepo(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
