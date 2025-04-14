using LearnAssist.Modules.Courses.Api.Database;
using Microsoft.EntityFrameworkCore;

namespace LearnAssist.Api.Extensions;

internal static class MigrationExtensions
{
    internal static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();
        ApplyMigrations<CoursesDbContext>(scope);
    }

    private static void ApplyMigrations<TDbContext>(IServiceScope scope) where TDbContext : DbContext
    {
        using TDbContext context = scope.ServiceProvider.GetRequiredService<TDbContext>();
        context.Database.Migrate();
    }
}