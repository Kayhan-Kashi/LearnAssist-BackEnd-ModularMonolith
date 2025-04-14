namespace LearnAssist.Modules.Courses.Domain.Courses;

public sealed class Subject
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string HisTime { get; set; }
    public string HisDate { get; set; }
    public DateTime CreatedAt { get; set; }
}