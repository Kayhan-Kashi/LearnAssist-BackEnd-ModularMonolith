using LearnAssist.Modules.Courses.Application.Courses;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace LearnAssist.Modules.Courses.Presentation.Courses;

public static class GetSubject
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("subjects/{id}", async (Guid id, ISender sender) =>
        {
            var query = new GetSubjectQuery(id);
            var subject = await sender.Send(query);
            return subject is null ? Results.NotFound() : Results.Ok(subject);

        }).WithTags(Tags.Courses);
    }
}