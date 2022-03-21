using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace GraduatedCylinder.Roslyn;

public sealed class DimensionReceiver : BaseReceiver
{

    public List<StructDeclarationSyntax> Structs { get; } = new();

    public IEnumerable<StructDeclarationSyntax> GetDimensions(Compilation compilation) {
        foreach (StructDeclarationSyntax @struct in Structs.OrderBy(s => s.Identifier.ToString())) {
            SemanticModel semanticModel = compilation.GetSemanticModel(@struct.SyntaxTree);
            ITypeSymbol? typeSymbol = (ITypeSymbol?)semanticModel.GetDeclaredSymbol(@struct);
            if (typeSymbol is null) {
                continue;
            }
            bool isDimension = typeSymbol.AllInterfaces.Any(@interface => @interface.Name == "IDimension");
            if (!isDimension) {
                continue;
            }
            yield return @struct;
        }
    }

    //this needs to catalog only and do it quickly
    public override void OnVisitSyntaxNode(SyntaxNode syntaxNode) {
        if (syntaxNode is StructDeclarationSyntax structSyntax) {
            Log($"Found struct {structSyntax.Identifier}");
            Structs.Add(structSyntax);
        }
    }

}