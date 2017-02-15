using System;
using System.Reflection;

namespace E15_ST3ProgrammeringExamOrdinary.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}