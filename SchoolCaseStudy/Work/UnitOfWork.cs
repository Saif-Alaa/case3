using SchoolCaseStudy.Data;
using SchoolCaseStudy.Repos.InterFaces;

namespace SchoolCaseStudy.Work
{
    public class UnitOfWork : IUnitOfWork
    {
        public IStudent Student { get; set; }

        public ITeacher Teacher { get; set; }
        public ICousrces Cousrces { get; set; }

        public IEnrollment Enrollment { get; set; }

        public IStudentProfile StudentProfile { get; set; }
        protected readonly AppDbContext appDbContext;

        public UnitOfWork(IStudent student, ITeacher teacher, ICousrces cousrces, IEnrollment enrollment, IStudentProfile studentProfile, AppDbContext appDbContext)
        {
            Student = student;
            Teacher = teacher;
            Cousrces = cousrces;
            Enrollment = enrollment;
            StudentProfile = studentProfile;
            this.appDbContext = appDbContext;
        }

        public void Save()
        {
            appDbContext.SaveChanges();
        }
    }
}
