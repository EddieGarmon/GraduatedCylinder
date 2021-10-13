using System;
using Microsoft.CodeAnalysis;

namespace GraduatedCylinder.Roslyn.IoT
{
    [Generator]
    public class UnitConverterGenerator : BaseGenerator
    {

        public UnitConverterGenerator()
            : base("GraduatedCylinder.IoT") { }

        protected override void ExecuteInternal(GeneratorExecutionContext context) { }

        protected override void InitializeInternal(GeneratorInitializationContext context) {
            Console.WriteLine("Generate Converters...");
        }

    }
}