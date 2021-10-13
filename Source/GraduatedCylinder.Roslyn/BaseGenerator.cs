using System;
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

        protected bool ShouldExecute { get; private set; }

        public void Execute(GeneratorExecutionContext context) {
            ShouldExecute = context.Compilation.AssemblyName == GeneratorFor;
            if (!ShouldExecute) {
                return;
            }
            try {
                ExecuteInternal(context);
            } catch (Exception e) {
                DiagnosticDescriptor descriptor =
                    new(GetType().Name, "Error", e.ToString(), "Error", DiagnosticSeverity.Error, true);
                Diagnostic diagnostic = Diagnostic.Create(descriptor, Location.None);
                context.ReportDiagnostic(diagnostic);
            }
        }

        public void Initialize(GeneratorInitializationContext context) {
            InitializeInternal(context);
        }

        protected abstract void ExecuteInternal(GeneratorExecutionContext context);

        protected abstract void InitializeInternal(GeneratorInitializationContext context);

    }
}