using System.Collections.Generic;
using Microsoft.CodeAnalysis;

namespace GraduatedCylinder.Roslyn
{
    public abstract class BaseReceiver : ISyntaxReceiver
    {

#if DEBUG
        internal List<string> Logs { get; } = new();
#endif

        public abstract void OnVisitSyntaxNode(SyntaxNode syntaxNode);

        protected void Log(string value) {
#if DEBUG
            Logs.Add(value);
#endif
        }

    }
}