using System;
using System.Collections.Generic;
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

            if (context.SyntaxReceiver is not UnitReceiver receiver) {
                return;
            }

            List<string> log = receiver.Logs;
            log.Insert(0, $"Execute Started: {DateTime.Now}");

            try {
                foreach (EnumDeclarationSyntax @enum in receiver.Enums) {
                    log.Add($"Generating for {@enum.Identifier}");
                    context.AddSource(GenerateConverterFor(@enum));
                }
            } finally {
                log.Add($"Execute Finished: {DateTime.Now}");
                string logContent = $"/*\r\n{string.Join(Environment.NewLine, receiver.Logs)}\r\n*/";
                context.AddSource("Units_Log.cs", logContent);
            }
        }

        protected override void InitializeInternal(GeneratorInitializationContext context) {
            context.RegisterForSyntaxNotifications(() => new UnitReceiver());
        }

        private GeneratedFile GenerateConverterFor(EnumDeclarationSyntax @enum) {
            string unitsTypeName = @enum.Identifier.Text;
            string dimensionTypeName = unitsTypeName.Substring(0, unitsTypeName.Length - 4);
            string converterTypeName = $@"{dimensionTypeName}Converter";
            string filename = $"{converterTypeName}.g.cs";
            string contents = @$"//Generated {DateTime.Now}
using System;

namespace GraduatedCylinder.Converters
{{
    internal static class {converterTypeName}
    {{

        public static {dimensionTypeName} FromBase(float baseValue, {unitsTypeName} wantedUnits) {{
{GenerateSwitch_FromBase(@enum)}
        }}

        public static float ToBase({dimensionTypeName} value) {{
{GenerateSwitch_ToBase(@enum)}
        }}

    }}
}}
";

            return new GeneratedFile(filename, contents);
        }

        private static string GenerateSwitch_FromBase(EnumDeclarationSyntax @enum) {
            return @" throw new NotImplementedException(); ";
        }

        private static string GenerateSwitch_ToBase(EnumDeclarationSyntax @enum) {
            return " throw new NotImplementedException(); ";
        }

        internal sealed class UnitReceiver : BaseReceiver
        {

            public List<EnumDeclarationSyntax> Enums { get; } = new();

            //this needs to catalog only and do it quickly
            public override void OnVisitSyntaxNode(SyntaxNode syntaxNode) {
                if (syntaxNode is EnumDeclarationSyntax enumSyntax) {
                    if (enumSyntax.Identifier.Text.EndsWith("Unit")) {
                        Log($"Found units enum {enumSyntax.Identifier}");
                        Enums.Add(enumSyntax);
                    }
                }
            }

        }

    }
}