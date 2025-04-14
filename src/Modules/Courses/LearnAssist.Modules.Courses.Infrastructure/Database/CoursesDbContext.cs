using LearnAssist.Modules.Courses.Api.Courses;
using LearnAssist.Modules.Courses.Application.Abstractions.Data;
using LearnAssist.Modules.Courses.Domain.Courses;
using Microsoft.EntityFrameworkCore;

namespace LearnAssist.Modules.Courses.Api.Database;

public sealed class CoursesDbContext(DbContextOptions<CoursesDbContext> options) : DbContext(options), IUnitOfWork
{
    internal DbSet<Subject> Subjects { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schemas.Courses);
    }
}   

internal static class Schemas
{
    internal const string Courses = "courses";
}