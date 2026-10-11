using SchoolCaseStudy.Repos.InterFaces;

namespace SchoolCaseStudy.Work
{
    public interface IUnitOfWork
    {
        IStudent Student { get; }
        ITeacher Teacher { get; }
        ICousrces Cousrces { get; }
        IEnrollment Enrollment { get; }
        IStudentProfile StudentProfile { get; }
        void Save();
    }
}
