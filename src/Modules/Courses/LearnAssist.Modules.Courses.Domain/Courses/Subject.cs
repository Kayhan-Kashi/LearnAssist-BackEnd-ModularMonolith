using LearnAssist.Modules.Courses.Domain.Abstractions;
using LearnAssist.Modules.Courses.Domain.Courses.Events;

namespace LearnAssist.Modules.Courses.Domain.Courses;

public sealed class Subject : Entity
{
    private Subject() {}
    
    public string Name { get; private set; }
    public string Description { get; private set; }

    public static Subject Create(string name, string description)
    {
        var subject = new Subject()
        {
            Id = Guid.NewGuid(),
            Name = name,
            Description = description,
        };
        
        subject.Raise(new SubjectCreatedDomainEvent(subject.Id));
        return subject;
    }
}