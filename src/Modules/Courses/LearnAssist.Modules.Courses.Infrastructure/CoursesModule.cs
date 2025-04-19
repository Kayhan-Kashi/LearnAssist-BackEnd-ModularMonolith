using System.Reflection.Metadata;
using FluentValidation;
using LearnAssist.Modules.Courses.Api.Database;
using LearnAssist.Modules.Courses.Application.Abstractions.Data;
using LearnAssist.Modules.Courses.Domain.Courses.Abstractions;
using LearnAssist.Modules.Courses.Infrastructure.Courses;
using LearnAssist.Modules.Courses.Infrastructure.Data;
using LearnAssist.Modules.Courses.Presentation.Courses;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Npgsql;

namespace LearnAssist.Modules.Courses.Infrastructure;

public static class CoursesModule
{
    public static void MapEndpoints(IEndpointRouteBuilder app)
    {
        CoursesEndpoints.MapEndpoints(app);
    }

    public static IServiceCollection AddCoursesModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblies(Application.AssemblyReference.Assembly);
        });
        services.AddValidatorsFromAssembly(Application.AssemblyReference.Assembly, includeInternalTypes: true);
        services.AddInfrastrucutre(configuration);
        return services;    
    }

    private static void AddInfrastrucutre(this IServiceCollection services, IConfiguration configuration)
    {
        string databaseConnectionString = configuration.GetConnectionString("Database")!;
        NpgsqlDataSource npgDataSource = new NpgsqlDataSourceBuilder(databaseConnectionString).Build();
        services.TryAddSingleton(npgDataSource);
        
        services.AddScoped<IDbConnectionFactory, DbConnectionFactory>(); 
        services.AddDbContext<CoursesDbContext>(options => 
            options.UseNpgsql(
                    databaseConnectionString,
                    npgsqlOptions => npgsqlOptions
                        .MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Courses))
                .UseSnakeCaseNamingConvention());

        services.AddScoped<ISubjectRepository, SubjectRepository>();
        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<CoursesDbContext>());
    }
}

