using LearnAssist.Modules.Courses.Application.Abstractions.Data;
using LearnAssist.Modules.Courses.Domain.Courses;
using LearnAssist.Modules.Courses.Domain.Courses.Abstractions;
using MediatR;

namespace LearnAssist.Modules.Courses.Application.Courses;

public sealed record CreateSubjectCommand(string Name, string Description) : IRequest<Guid>; 
    

internal sealed class CreateSubjectCommandHandler(ISubjectRepository subjectRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateSubjectCommand, Guid>
{
    public async Task<Guid> Handle(CreateSubjectCommand request, CancellationToken cancellationToken)
    {
        var subject = new Subject
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            CreatedAt = DateTime.UtcNow,
            HisDate =  "14031218",
            HisTime = DateTime.Now.TimeOfDay.ToString()
        };
            
        subjectRepository.Insert(subject);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return subject.Id;
    }
}