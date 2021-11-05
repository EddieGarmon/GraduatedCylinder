using System.IO;
using Microsoft.CodeAnalysis;

namespace GraduatedCylinder.Roslyn
{
    public class GeneratedFile
    {

        public GeneratedFile(string fileName, string content) {
            FileName = fileName;
            Content = content;
        }

        public string Content { get; }

        public string FileName { get; }

        public void AddToContext(GeneratorExecutionContext context) {
            context.AddSource(FileName, Content);
        }

        public void SaveToDisk() {
            //todo: ensure directory?
            File.WriteAllText(FileName, Content);
        }

    }
}