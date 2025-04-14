using LearnAssist.Modules.Courses.Application.Courses;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace LearnAssist.Modules.Courses.Presentation.Courses;

public static class CreateSubject
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("subjects", async (Request request, ISender sender) =>
        {
            var command = new CreateSubjectCommand(request.Name, request.Description);
            Guid subjectId = await sender.Send(command);
            return Results.Ok(subjectId);
            
        }).WithTags(Tags.Courses);
    }

    private sealed class Request
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string HisTime { get; set; }
        public string HisDate { get; set; }
        public DateTime CreatedAt { get; set; }
    }
    
}