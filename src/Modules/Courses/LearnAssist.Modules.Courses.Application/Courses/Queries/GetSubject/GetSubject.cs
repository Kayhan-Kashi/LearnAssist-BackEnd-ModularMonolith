using System.Data.Common;
using Dapper;
using LearnAssist.Modules.Courses.Api.Courses;
using LearnAssist.Modules.Courses.Application.Abstractions.Data;
using MediatR;

namespace LearnAssist.Modules.Courses.Application.Courses;

public sealed record GetSubjectQuery(Guid Id) : IRequest<SubjectResponse1?>; 

internal sealed class GetSubjectQueryHandler(IDbConnectionFactory dbConnectionFactory) : IRequestHandler<GetSubjectQuery, SubjectResponse1?>
{
    public async Task<SubjectResponse1?> Handle(GetSubjectQuery request, CancellationToken cancellationToken)
    {
        await using DbConnection connection = await dbConnectionFactory.OpenConnectionAsync();
        
        const string sql =
            $""" 
                 SELECT 
                     id as {nameof(SubjectResponse1.Id)},
                     name as {nameof(SubjectResponse1.Name)},
                     description as {nameof(SubjectResponse1.Description)}
                 FROM courses.subjects
                 WHERE id = @Id
             """;

        SubjectResponse1? subject = await connection.QuerySingleOrDefaultAsync<SubjectResponse1>(sql, request);
        return subject;
    }
}