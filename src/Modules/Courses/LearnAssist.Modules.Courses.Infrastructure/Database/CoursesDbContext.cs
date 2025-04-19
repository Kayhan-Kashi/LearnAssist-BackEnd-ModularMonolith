using System.Globalization;
using LearnAssist.Modules.Courses.Api.Courses;
using LearnAssist.Modules.Courses.Application.Abstractions.Data;
using LearnAssist.Modules.Courses.Domain.Abstractions;
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
    
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        SetDateProperties();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void SetDateProperties()
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e.State == EntityState.Added && e.Entity is Entity);

        foreach (var entry in entries)
        {
            ((Entity)entry.Entity).CreatedAt = DateTime.UtcNow;
            var persianCalendar = new PersianCalendar();
            DateTime dateTime = DateTime.Now;
            var year = persianCalendar.GetYear(dateTime);
            var month = persianCalendar.GetMonth(dateTime).ToString("D2");
            var hour =  persianCalendar.GetHour(dateTime).ToString("D2"); ;
            var minute = persianCalendar.GetMinute(dateTime).ToString("D2");
            var day = persianCalendar.GetDayOfMonth(dateTime).ToString("D2");
            ((Entity)entry.Entity).HisDate = $"{year}{month}{day}";
            ((Entity)entry.Entity).HisTime = $"{hour}:{minute}";
        }
    }
}   

internal static class Schemas
{
    internal const string Courses = "courses";
}