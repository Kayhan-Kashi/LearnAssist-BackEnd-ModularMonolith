using LearnAssist.Modules.Courses.Domain.Abstractions;

namespace LearnAssist.Modules.Courses.Domain.Courses.Events;

public sealed class SubjectCreatedDomainEvent(Guid subjectId) : IDomainEvent
{
    public Guid SubjectId { get; init; } = subjectId;
}