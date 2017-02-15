using System;
using System.Reflection;

namespace E16_ST3ITS3ExamOrdinary.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}