using System;
using System.Collections.Generic;
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