using Microsoft.EntityFrameworkCore;
using SchoolCaseStudy.Data;
using SchoolCaseStudy.GanaricRepos;
using SchoolCaseStudy.Models;
using SchoolCaseStudy.Repos.InterFaces;

namespace SchoolCaseStudy.Repos.CustomRepo
{
    public class CourseRepo : GanaricRepo<Course>, ICousrces
    {
        
        public CourseRepo(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<List<Course>> Coursewithhours()
        {
           return   appDbContext.courses.Include(t => t.Teacher).ToList();
        }
    }
}
