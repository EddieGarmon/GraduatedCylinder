using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CodeGeneration;

internal class UnitsInfo
{

    public UnitsInfo(EnumDeclarationSyntax @enum, List<(EnumMemberDeclarationSyntax member, ISymbol)> members) {
        Enum = @enum;
        Members = members;
        NameSet = NameSet.FromUnitsType(@enum.Identifier.ToString());
        Namespace = @enum.GetNamespace();
        ValueType = Namespace == Names.GraduatedCylinder ? "double" : "float";
    }

    public EnumDeclarationSyntax Enum { get; }

    public List<(EnumMemberDeclarationSyntax member, ISymbol symbol)> Members { get; }

    public NameSet NameSet { get; }

    public string Namespace { get; }

    public string ValueType { get; }

}