using FluentValidation;
using LearnAssist.Modules.Courses.Application.Abstractions.Data;
using LearnAssist.Modules.Courses.Domain.Courses;
using LearnAssist.Modules.Courses.Domain.Courses.Abstractions;
using MediatR;

namespace LearnAssist.Modules.Courses.Application.Courses;

public sealed record CreateSubjectCommand(string Name, string Description) : IRequest<Guid>;

internal sealed class CreateSubjectCommandValidator : AbstractValidator<CreateSubjectCommand>
{
    public CreateSubjectCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
    }
}
    

internal sealed class CreateSubjectCommandHandler(ISubjectRepository subjectRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateSubjectCommand, Guid>
{
    public async Task<Guid> Handle(CreateSubjectCommand request, CancellationToken cancellationToken)
    {
        var subject = Subject.Create(
            request.Name,
            request.Description
        );
            
        subjectRepository.Insert(subject);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return subject.Id;
    }
}