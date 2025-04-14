using Microsoft.AspNetCore.Routing;

namespace LearnAssist.Modules.Courses.Presentation.Courses;

public static class CoursesEndpoints
{
    public static void MapEndpoints(IEndpointRouteBuilder app)
    {
        CreateSubject.MapEndpoint(app);
        GetSubject.MapEndpoint(app);
    }
}