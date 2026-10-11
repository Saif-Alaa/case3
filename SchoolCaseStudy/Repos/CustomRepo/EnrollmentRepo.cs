using Microsoft.EntityFrameworkCore;
using SchoolCaseStudy.Data;
using SchoolCaseStudy.GanaricRepos;
using SchoolCaseStudy.Models;
using SchoolCaseStudy.Repos.InterFaces;

namespace SchoolCaseStudy.Repos.CustomRepo
{
    public class EnrollmentRepo : GanaricRepo<Enrollment>, IEnrollment
    {
        public EnrollmentRepo(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<List<Enrollment>> GetEnrollmentByCourse()
        {
            return  appDbContext.enrollments.Include(s => s.course)
                .ToList();
        }

        public async Task<List<Enrollment>> GetEnrollmentByStudent()
        {
            return appDbContext.enrollments.Include(s => s.Student)
                           .ToList();
        }
    }
}
