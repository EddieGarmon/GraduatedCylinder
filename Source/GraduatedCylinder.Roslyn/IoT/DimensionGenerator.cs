using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace GraduatedCylinder.Roslyn.IoT
{
    [Generator]
    public class DimensionGenerator : BaseGenerator
    {

        public DimensionGenerator()
            : base("GraduatedCylinder.IoT") { }

        protected override void ExecuteInternal(GeneratorExecutionContext context) {
            if (context.SyntaxReceiver is not DimensionReceiver receiver) {
                return;
            }

            List<string> log = receiver.Logs;
            log.Insert(0, $"Execute Started: {DateTime.Now}");

            try {
                foreach (StructDeclarationSyntax @struct in receiver.Structs) {
                    log.Add($"Generating for {@struct.Identifier}");
                    string source = GenerateFor(@struct);
                    context.AddSource($"{@struct.Identifier}.g.cs", source);
                }
            } finally {
                log.Add($"Execute Finished: {DateTime.Now}");
                string logContent = $"/*\r\n{string.Join(Environment.NewLine, receiver.Logs)}\r\n*/";
                context.AddSource("Dimensions_Log.cs", logContent);
            }
        }

        protected override void InitializeInternal(GeneratorInitializationContext context) {
            context.RegisterForSyntaxNotifications(() => new DimensionReceiver());
        }

        private static string GenerateFor(StructDeclarationSyntax @struct) {
            string format = @"//Generated {1}
using System;
using GraduatedCylinder.Converters;

namespace GraduatedCylinder
{{
    public partial struct {0} : IComparable<{0}>, IEquatable<{0}>
    {{

         public int CompareTo({0} other) {{
            int unitsComparison = _units.CompareTo(other._units);
            if (unitsComparison != 0) {{
                float thisInBase = {0}Converter.ToBase(this);
                float otherInBase = {0}Converter.ToBase(other);
                return thisInBase.CompareTo(otherInBase);
            }}
            return _value.CompareTo(other._value);
        }}

        public bool Equals({0} other) {{
            return CompareTo(other) == 0;
        }}

        public override bool Equals(object obj) {{
            return obj is {0} other && Equals(other);
        }}

        public override int GetHashCode() {{
            //todo: should this be dimension type and value in base?
            return HashCode.Combine((int)_units, _value);
        }}

        public {0} In({0}Unit units) {{
            if (Units == units) {{
                return this;
            }}
            float baseValue = {0}Converter.ToBase(this);
            return {0}Converter.FromBase(baseValue, units);
        }}

    }}
}}";
            return string.Format(format, @struct.Identifier, DateTime.Now);
        }

        internal sealed class DimensionReceiver : BaseReceiver
        {

            public List<StructDeclarationSyntax> Structs { get; } = new();

            //this needs to catalog only and do it quickly
            public override void OnVisitSyntaxNode(SyntaxNode syntaxNode) {
                if (syntaxNode is StructDeclarationSyntax structSyntax) {
                    Log($"Found struct {structSyntax.Identifier}");
                    Structs.Add(structSyntax);
                }
            }

        }

    }
}