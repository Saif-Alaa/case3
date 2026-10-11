using SchoolCaseStudy.GanaricRepos;
using SchoolCaseStudy.Models;

namespace SchoolCaseStudy.Repos.InterFaces
{
    public interface ICousrces : IGanaricRepo<Course>
    {
        Task<List<Course>> Coursewithhours();
    }
}
