namespace LearnAssist.Modules.Courses.Api.Courses;

public sealed class SubjectResponse1
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string HisDate { get; set; }
    public string HisTime { get; set; }
}

public sealed class SubjectResponse(
    Guid Id,
    string Name,
    string Description,
    string HisDate,
    string HisTime
);