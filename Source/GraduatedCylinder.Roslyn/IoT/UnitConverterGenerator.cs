using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace GraduatedCylinder.Roslyn.IoT
{
    [Generator]
    public class UnitConverterGenerator : BaseGenerator
    {

        public UnitConverterGenerator()
            : base("GraduatedCylinder.IoT") { }

        protected override void ExecuteInternal(GeneratorExecutionContext context) {
            //Debugger.Launch();

            if (context.SyntaxReceiver is not CustomReceiver receiver) {
                return;
            }

            string logContent =
                $@"/*
{string.Join(Environment.NewLine, receiver.Log)}
*/";
            context.AddSource("Logs.cs", logContent);
            
            EnsureRequiredReferences(context);

            string? scalesPath = context.Compilation.References
                                        .Single(metadata =>
                                                    (metadata.Display ?? string.Empty).EndsWith(
                                                        "GraduatedCylinder.Scales.dll"))
                                        .Display;

            byte[] scalesContent = File.ReadAllBytes(scalesPath);
            //get GC.Scales assembly,
            Assembly scales = Assembly.Load(scalesContent);

            List<GeneratedFile> generatedFiles = scales.GetTypes()
                                                       // reflect all enumerations of 'xxUnit'
                                                       .Where(t => t.IsPublic && t.IsEnum && t.Name.EndsWith("Unit"))
                                                       // one converter for each dimension
                                                       .Select(GenerateConverter)
                                                       .ToList();

            foreach (GeneratedFile generatedFile in generatedFiles) {
                context.AddSource(generatedFile);
            }
        }

        protected override void InitializeInternal(GeneratorInitializationContext context) {
            context.RegisterForSyntaxNotifications(() => new CustomReceiver());
        }

        private static void EnsureRequiredReferences(GeneratorExecutionContext context) {
            //todo? convert this into standalone required reference diagnostic
            if (!context.Compilation.ReferencedAssemblyNames.Any(
                    ai => ai.Name.Equals("GraduatedCylinder.Scales", StringComparison.OrdinalIgnoreCase))) {
                context.ReportDiagnostic(Diagnostic.Create("G001",
                                                           "GraduatedCylinder",
                                                           "You must reference \"GraduatedCylinder.Scales\" to use the generated code.",
                                                           DiagnosticSeverity.Error,
                                                           DiagnosticSeverity.Error,
                                                           true,
                                                           0));
            }
        }

        private static GeneratedFile GenerateConverter(Type enumerationType) {
            string unitsTypeName = enumerationType.Name;
            string dimensionTypeName = unitsTypeName.Substring(0, unitsTypeName.Length - 4);
            string converterTypeName = $@"{dimensionTypeName}Converter";
            string filename = $"{converterTypeName}.g.cs";
            string contents = @$"
using System;
using GraduatedCylinder.Units;

namespace GraduatedCylinder.Converters
{{
    internal static class {converterTypeName}
    {{

        public static {dimensionTypeName} FromBase(float baseValue, {unitsTypeName} wantedUnits) {{
{GenerateFromBaseSwitch(enumerationType)}
        }}

        public static float ToBase({dimensionTypeName} value) {{
{GenerateToBaseSwitch(enumerationType)}
        }}

    }}
}}
";

            return new GeneratedFile(filename, contents);
        }

        private static string GenerateFromBaseSwitch(Type enumerationType) {
            return @" throw new NotImplementedException(); ";
        }

        private static string GenerateToBaseSwitch(Type enumerationType) {
            return " throw new NotImplementedException(); ";
        }

        internal sealed class CustomReceiver : ISyntaxReceiver
        {

            public List<string> Log { get; } = new();

            public List<EnumDeclarationSyntax> Enums { get; } = new();

            public List<StructDeclarationSyntax> Structs { get; } = new();

            public void OnVisitSyntaxNode(SyntaxNode syntaxNode) {
                if (syntaxNode is StructDeclarationSyntax structSyntax) {
                    Log.Add($"Found struct {structSyntax.Identifier}");
                    Structs.Add(structSyntax);
                }
                if (syntaxNode is EnumDeclarationSyntax enumSyntax) {
                    Log.Add($"Found enum {enumSyntax.Identifier}");
                    Enums.Add(enumSyntax);
                }

            }

        }

    }
}