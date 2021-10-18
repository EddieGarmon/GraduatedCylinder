using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.CodeAnalysis;

namespace GraduatedCylinder.Roslyn
{
    public abstract class BaseGenerator : ISourceGenerator
    {

        protected BaseGenerator(string generatorFor) {
            GeneratorFor = generatorFor;
        }

        /// <summary>
        /// Assembly Name for which this generator should run
        /// </summary>
        public string GeneratorFor { get; }

        protected StringBuilder Buffer { get; set; } = new StringBuilder(); //size=16384?

#if DEBUG
        private List<string> Logs { get; set; } = new();
#endif

        public void Execute(GeneratorExecutionContext context) {
            if (context.Compilation.AssemblyName != GeneratorFor) {
                return;
            }
            try {
                if (context.SyntaxReceiver is BaseReceiver receiver) {
                    Logs = receiver.Logs;
                }
                Log($"Execute Started: {DateTime.Now:O}");
                ExecuteInternal(context);
            } catch (Exception e) {
                DiagnosticDescriptor descriptor =
                    new(GetType().Name, "Error", e.ToString(), "Error", DiagnosticSeverity.Error, true);
                Diagnostic diagnostic = Diagnostic.Create(descriptor, Location.None);
                context.ReportDiagnostic(diagnostic);
            } finally {
                Log($"Execute Finished: {DateTime.Now:O}");
                string logContent = $"/*\r\n{string.Join(Environment.NewLine, Logs)}\r\n*/";
                context.AddSource($"{GetType().Name}_Log.cs", logContent);
            }
        }

        public void Initialize(GeneratorInitializationContext context) {
            InitializeInternal(context);
        }

        protected GeneratedFile BufferToGeneratedFile(string fileName) {
            GeneratedFile file = new GeneratedFile(fileName, Buffer.ToString());
            Buffer.Clear();
            return file;
        }

        protected abstract void ExecuteInternal(GeneratorExecutionContext context);

        protected abstract void InitializeInternal(GeneratorInitializationContext context);

        protected void Log(string value) {
#if DEBUG
            Logs.Add(value);
#endif
        }

    }
}