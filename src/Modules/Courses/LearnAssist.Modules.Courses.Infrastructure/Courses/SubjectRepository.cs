using LearnAssist.Modules.Courses.Api.Database;
using LearnAssist.Modules.Courses.Domain.Courses;
using LearnAssist.Modules.Courses.Domain.Courses.Abstractions;

namespace LearnAssist.Modules.Courses.Infrastructure.Courses;

internal sealed class SubjectRepository(CoursesDbContext context) : ISubjectRepository
{
    public void Insert(Subject subject)
    {
        context.Subjects.Add(subject);
    }
}