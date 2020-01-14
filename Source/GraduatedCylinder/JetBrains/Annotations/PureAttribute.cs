using System;

namespace JetBrains.Annotations
{
    /// <summary>
    ///     Indicates that a method does not make any observable state changes.
    /// </summary>
    /// <example>
    ///     <code>
    ///  [Pure]
    ///  private int Multiply(int x, int y)
    ///  {
    ///    return x*y;
    ///  }
    /// 
    ///  public void Foo()
    ///  {
    ///    const int a=2, b=2;
    ///    Multiply(a, b); // Waring: Return value of pure method is not used
    ///  }
    ///  </code>
    /// </example>
    [AttributeUsage(AttributeTargets.Method)]
    internal sealed class PureAttribute : Attribute { }
}