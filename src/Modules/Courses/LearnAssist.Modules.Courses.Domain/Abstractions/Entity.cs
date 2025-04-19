namespace LearnAssist.Modules.Courses.Domain.Abstractions;

public abstract class Entity
{
    protected Entity() { }      
    protected Entity(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; init; }
    public string HisDate { get; set; }
    public string HisTime { get; set; }
    public DateTime CreatedAt { get; set; }

    private readonly List<IDomainEvent> _domainEvents = [];
    
    public void ClearDomainEvents() => _domainEvents?.Clear();
    
    protected void Raise(IDomainEvent domainEvent) => _domainEvents?.Add(domainEvent);

    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.ToList();
}