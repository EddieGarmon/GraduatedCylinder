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

    }
}