using Microsoft.CodeAnalysis;

namespace GraduatedCylinder.Roslyn
{
    public static class GeneratorExecutionContextExtensions
    {

        public static void AddSource(this GeneratorExecutionContext context, GeneratedFile file) {
            context.AddSource(file.FileName, file.Content);
        }

    }
}