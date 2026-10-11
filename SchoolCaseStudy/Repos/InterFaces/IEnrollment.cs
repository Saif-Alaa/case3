using SchoolCaseStudy.GanaricRepos;
using SchoolCaseStudy.Models;

namespace SchoolCaseStudy.Repos.InterFaces
{
    public interface IEnrollment : IGanaricRepo<Enrollment>
    {
        Task<List<Enrollment>> GetEnrollmentByStudent();
        Task<List<Enrollment>> GetEnrollmentByCourse();
    }
}
