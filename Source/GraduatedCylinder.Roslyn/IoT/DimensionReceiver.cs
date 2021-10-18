using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace GraduatedCylinder.Roslyn.IoT
{
    public sealed class DimensionReceiver : BaseReceiver
    {

        public List<StructDeclarationSyntax> Structs { get; } = new();

        //this needs to catalog only and do it quickly
        public override void OnVisitSyntaxNode(SyntaxNode syntaxNode) {
            if (syntaxNode is StructDeclarationSyntax structSyntax) {
                Log($"Found struct {structSyntax.Identifier}");

                BaseTypeSyntax? singleOrDefault = structSyntax.BaseList?.Types.SingleOrDefault(syntax => syntax.ToString().StartsWith("IDimension"));
                Structs.Add(structSyntax);
            }
        }

    }

}