using Microsoft.EntityFrameworkCore;
using SchoolCaseStudy.Data;
using SchoolCaseStudy.GanaricRepos;
using SchoolCaseStudy.Repos.CustomRepo;
using SchoolCaseStudy.Repos.InterFaces;
using AutoMapper;
using SchoolCaseStudy.Work;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("Name")));
builder.Services.AddScoped(typeof(IGanaricRepo<>), typeof(GanaricRepo<>));
builder.Services.AddScoped<IStudent, StudentRepo>();
builder.Services.AddScoped<ICousrces, CourseRepo>();
builder.Services.AddScoped<ITeacher, TeacherRepo>();
builder.Services.AddScoped<IEnrollment, EnrollmentRepo>();
builder.Services.AddScoped<IStudentProfile, StudentProfilerepo>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
