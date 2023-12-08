using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CodeGeneration;

internal static class RoslynExtensions
{

    public static DimensionInfo? GetDimensionInfo(this GeneratorSyntaxContext context) {
        StructDeclarationSyntax @struct = (StructDeclarationSyntax)context.Node;
        return context.SemanticModel.GetDeclaredSymbol(@struct) is not ITypeSymbol typeSymbol ? null : typeSymbol.GetDimensionInfo();
    }

    public static DimensionInfo? GetDimensionInfo(this ITypeSymbol symbol) {
        if (!symbol.IsDimension()) {
            return null;
        }
        INamespaceSymbol? @namespace = symbol.ContainingNamespace;
        if (@namespace is null) {
            return null;
        }
        return @namespace.Name switch {
            "GraduatedCylinder" => new DimensionInfo("GraduatedCylinder", symbol.Name),
            "Pipette" => new DimensionInfo("Pipette", symbol.Name),
            _ => null
        };
    }

    /// <summary>
    ///     Determine the namespace the class/enum/struct is declared in, if any
    /// </summary>
    /// <param name="syntax"></param>
    /// <returns></returns>
    public static string GetNamespace(this BaseTypeDeclarationSyntax syntax) {
        // If we don't have a namespace at all we'll return an empty string
        // This accounts for the "default namespace" case
        string nameSpace = string.Empty;

        // Get the containing syntax node for the type declaration
        // (could be a nested type, for example)
        SyntaxNode? potentialNamespaceParent = syntax.Parent;

        // Keep moving "out" of nested classes etc until we get to a namespace
        // or until we run out of parents
        while (potentialNamespaceParent != null &&
               potentialNamespaceParent is not NamespaceDeclarationSyntax &&
               potentialNamespaceParent is not FileScopedNamespaceDeclarationSyntax) {
            potentialNamespaceParent = potentialNamespaceParent.Parent;
        }

        // Build up the final namespace by looping until we no longer have a namespace declaration
        if (potentialNamespaceParent is BaseNamespaceDeclarationSyntax namespaceParent) {
            // We have a namespace. Use that as the type
            nameSpace = namespaceParent.Name.ToString();

            // Keep moving "out" of the namespace declarations until we 
            // run out of nested namespace declarations
            while (true) {
                if (namespaceParent.Parent is not NamespaceDeclarationSyntax parent) {
                    break;
                }

                // Add the outer namespace as a prefix to the final namespace
                nameSpace = $"{namespaceParent.Name}.{nameSpace}";
                namespaceParent = parent;
            }
        }

        // return the final namespace
        return nameSpace;
    }

    public static UnitsInfo? GetUnitsInfo(this GeneratorSyntaxContext context) {
        EnumDeclarationSyntax @enum = (EnumDeclarationSyntax)context.Node;

        if (context.SemanticModel.GetDeclaredSymbol(@enum) is not ITypeSymbol typeSymbol) {
            return null;
        }
        if (!typeSymbol.IsUnits()) {
            return null;
        }

        //todo: ensure base type is 'short'

        List<(EnumMemberDeclarationSyntax, ISymbol)> members =
            @enum.Members.Select(member => (member, context.SemanticModel.GetDeclaredSymbol(member)!)).ToList();

        return new UnitsInfo(@enum, members);
    }

    public static bool IsDimension(this ITypeSymbol typeSymbol) {
        const string interfaceName = "IDimension";
        return typeSymbol.Name != interfaceName && typeSymbol.AllInterfaces.Any(@interface => @interface.Name == interfaceName);
    }

    public static bool IsUnits(this ITypeSymbol typeSymbol) {
        return typeSymbol.GetAttributes().Any(attribute => attribute.AttributeClass?.Name == "UnitsForAttribute");
    }

}