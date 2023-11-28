using System.Diagnostics.CodeAnalysis;
using Microsoft.CodeAnalysis;

namespace GraduatedCylinder.Roslyn;

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

    [SuppressMessage("MicrosoftCodeAnalysisCorrectness",
                     "RS1035:Do not use APIs banned for analyzers",
                     Justification = "Were doin our own thing")]
    public void SaveToDisk() {
        //todo: ensure directory?
        File.WriteAllText(FileName, Content);
    }

}