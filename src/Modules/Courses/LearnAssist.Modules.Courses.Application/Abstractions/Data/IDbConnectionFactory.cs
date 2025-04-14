using System.Data.Common;

namespace LearnAssist.Modules.Courses.Application.Abstractions.Data;

public interface IDbConnectionFactory
{
    ValueTask<DbConnection> OpenConnectionAsync();
}