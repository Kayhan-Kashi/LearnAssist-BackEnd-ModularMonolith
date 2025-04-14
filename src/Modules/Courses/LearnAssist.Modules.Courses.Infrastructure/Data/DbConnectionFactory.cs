using System.Data.Common;
using LearnAssist.Modules.Courses.Application.Abstractions.Data;
using Npgsql;

namespace LearnAssist.Modules.Courses.Infrastructure.Data;

public sealed class DbConnectionFactory(NpgsqlDataSource dataSource) : IDbConnectionFactory
{
    public async ValueTask<DbConnection> OpenConnectionAsync()
    {
        return await dataSource.OpenConnectionAsync();
    }
}