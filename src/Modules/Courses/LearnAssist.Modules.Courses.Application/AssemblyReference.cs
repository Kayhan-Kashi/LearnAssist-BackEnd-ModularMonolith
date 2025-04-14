using System.Reflection;

namespace LearnAssist.Modules.Courses.Application;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}