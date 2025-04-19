namespace LearnAssist.Modules.Courses.Domain.Abstractions;

public class DomainEvent : IDomainEvent
{
    public DomainEvent()
    {
        Id = Guid.NewGuid();
        OccurredOnUtc = DateTime.UtcNow;
    }
    
    public DomainEvent(Guid id, DateTime occurredOnUtc)
    {
        Id = id;
        OccurredOnUtc = occurredOnUtc;
    }
    
    public Guid Id { get; init; }
    public DateTime OccurredOnUtc { get; init; }
}