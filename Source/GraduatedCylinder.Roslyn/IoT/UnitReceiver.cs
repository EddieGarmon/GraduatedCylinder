using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace GraduatedCylinder.Roslyn.IoT
{
    public sealed class UnitReceiver : BaseReceiver
    {

        public UnitReceiver() {
            Log($"Receiver Created: {DateTime.Now:O}");
        }

        public List<EnumDeclarationSyntax> Enums { get; } = new();

        public IEnumerable<EnumDeclarationSyntax> GetUnits(Compilation compilation) {
            //todo: ensure enum has base type of short
            foreach (EnumDeclarationSyntax? @enum in Enums.OrderBy(s => s.Identifier.ToString())) {
                SemanticModel semanticModel = compilation.GetSemanticModel(@enum.SyntaxTree);
                INamedTypeSymbol? symbol = (INamedTypeSymbol?)semanticModel.GetDeclaredSymbol(@enum);
                if (symbol is null) {
                    continue;
                }
                bool isUnit = symbol.EnumUnderlyingType?.ToDisplayString() == "short";
                if (!isUnit) {
                    continue;
                }
                yield return @enum;
            }

            // return Enums.OrderBy(e => e.Identifier.ToString());
        }

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