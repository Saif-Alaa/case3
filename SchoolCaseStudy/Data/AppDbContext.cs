using Microsoft.EntityFrameworkCore;
using SchoolCaseStudy.Models;

namespace SchoolCaseStudy.Data
{
    public class AppDbContext : DbContext
    {

        public DbSet<Student> students { get; set; }
        public DbSet<StudentProfile> studentProfiles { get; set; }
        public DbSet<Course> courses { get; set; }
        public DbSet<Enrollment> enrollments { get; set; }
        public DbSet<Teacher> teachers  { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasOne(sp => sp.StudentProfile)
                .WithOne(s => s.Student)
                .HasForeignKey<StudentProfile>(fk => fk.StudentId)
                                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Teacher>().HasMany(c => c.courses)
                .WithOne(t => t.Teacher)
                .HasForeignKey(fk => fk.TeacherId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Student>().HasMany(e => e.enrollments)
                .WithOne(s => s.Student)
                .HasForeignKey(fk => fk.StudentId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Course>().HasMany(e => e.enrollments)
                .WithOne(s => s.course)
                .HasForeignKey(fk => fk.CourseId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Enrollment>()
                .HasIndex(e => new { e.StudentId, e.CourseId })
                .IsUnique();


            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    FullName = "Ali Hassan",
                    Email = "ali_hassan@gmail.com",
                    Phone = "01011111111",
                    DirthDate = new DateTime(2010, 05, 12, 0, 0, 0),
                    Gender = "Male"
                },
                   new Student
                   {
                       Id = 2,
                       FullName = "Mariam Ahmed",
                       Email = "mariam.ahmed@school.com",
                       Phone = "01022222222",
                       DirthDate = new DateTime(2018, 08, 20, 0, 0, 0),
                       Gender = "Female"
                   }, new Student
                   {
                       Id = 3,
                       FullName = "Omar Khaled",
                       Email = "omar.khaled@school.com",
                       Phone = "01033333333",
                       DirthDate = new DateTime(2009, 11, 05, 0, 0, 0),
                       Gender = "Male"
                   }
                );



            modelBuilder.Entity<StudentProfile>().HasData(
                new StudentProfile
                {
                    Id = 1,
                    Address = "Nasr City, Cairo",
                    ParentPhone = "01111111111",
                    EmergencyContact = "01211111111",
                    StudentId = 1
                },
                   new StudentProfile
                   {
                       Id = 2,
                       Address = "Heliopolis, Cairo",
                       ParentPhone = "01122222222",
                       EmergencyContact = "01222222222",
                       StudentId = 2
                   }, new StudentProfile
                   {
                       Id = 3,
                       Address = "Maadi, Cairo",
                       ParentPhone = "01133333333",
                       EmergencyContact = "01233333333",
                       StudentId = 3
                   }
                );


            modelBuilder.Entity<Teacher>().HasData(
                new Teacher
                {
                    Id = 1,
                    FullName = "Ahmed Samir",
                    Email = "ahmed.samir@school.com",
                    Phone = "01044444444",
                    HireDate = new DateTime(2020, 09, 01, 0, 0, 0),
                },
                    new Teacher
                    {
                        Id = 2,
                        FullName = "Nour Adel",
                        Email = "nour.adel@school.com",
                        Phone = "01055555555",
                        HireDate = new DateTime(2021, 02, 15, 0, 0, 0),
                    },




    new Teacher
    {
        Id = 3,
        FullName = "Hany Mostafa",
        Email = "hany.mostafa@school.com",
        Phone = "01066666666",
        HireDate = new DateTime(2019, 08, 20, 0, 0, 0),
    }
                                );

            modelBuilder.Entity<Course>().HasData(

                    new Course 
                    {
                        Id = 1 ,
                        Title = "Programming Fundamentals",
                        CreditHours = 3,
                        TeacherId = 1 
                    },
                         new Course
                         {
                             Id = 2,
                             Title = "Database Systems",
                             CreditHours = 4,
                             TeacherId = 2
                         },
                              new Course
                              {
                                  Id = 3,
                                  Title = "Web Development",
                                  CreditHours = 3,
                                  TeacherId = 1
                              }
                    );

            modelBuilder.Entity<Enrollment>().HasData(

                new Enrollment
                {
                    Id = 1,
                    StudentId = 1,
                    CourseId = 1,
                    EnrollmentDate = new DateTime(2026, 09, 01),
                    Grade = 90.00m
                },
                  new Enrollment
                  {
                      Id = 2,
                      StudentId = 2,
                      CourseId = 2,
                      EnrollmentDate = new DateTime(2026, 09, 02),
                      Grade = 85.00m
                  }, new Enrollment
                  {
                      Id = 3,
                      StudentId = 3,
                      CourseId = 3,
                      EnrollmentDate = new DateTime(2026, 09, 03),
                      Grade = null
                  }
                );


        }

    }
}
