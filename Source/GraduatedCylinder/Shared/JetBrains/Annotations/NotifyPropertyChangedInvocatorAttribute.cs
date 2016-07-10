﻿using System;

namespace JetBrains.Annotations
{
    /// <summary>
    ///     Indicates that the method is contained in a type that implements
    ///     <see cref="System.ComponentModel.INotifyPropertyChanged" /> interface
    ///     and this method is used to notify that some property value changed.
    /// </summary>
    /// <remarks>
    ///     The method should be non-static and conform to one of the supported signatures:
    ///     <list>
    ///         <item>
    ///             <c>NotifyChanged(string)</c>
    ///         </item>
    ///         <item>
    ///             <c>NotifyChanged(params string[])</c>
    ///         </item>
    ///         <item>
    ///             <c>NotifyChanged{T}(Expression{Func{T}})</c>
    ///         </item>
    ///         <item>
    ///             <c>NotifyChanged{T,U}(Expression{Func{T,U}})</c>
    ///         </item>
    ///         <item>
    ///             <c>SetProperty{T}(ref T, T, string)</c>
    ///         </item>
    ///     </list>
    /// </remarks>
    /// <example>
    ///     <code>
    ///  public class Foo : INotifyPropertyChanged
    ///  {
    ///    public event PropertyChangedEventHandler PropertyChanged;
    /// 
    ///    [NotifyPropertyChangedInvocator]
    ///    protected virtual void NotifyChanged(string propertyName)
    ///    {}
    /// 
    ///    private string _name;
    ///    public string Name
    ///    {
    ///      get { return _name; }
    ///      set
    ///      {
    ///        _name = value;
    ///        NotifyChanged("LastName"); // Warning
    ///      }
    ///    }
    ///  }
    ///  </code>
    ///     Examples of generated notifications:
    ///     <list>
    ///         <item>
    ///             <c>NotifyChanged("Property")</c>
    ///         </item>
    ///         <item>
    ///             <c>NotifyChanged(() => Property)</c>
    ///         </item>
    ///         <item>
    ///             <c>NotifyChanged((VM x) => x.Property)</c>
    ///         </item>
    ///         <item>
    ///             <c>SetProperty(ref myField, value, "Property")</c>
    ///         </item>
    ///     </list>
    /// </example>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    internal sealed class NotifyPropertyChangedInvocatorAttribute : Attribute
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="NotifyPropertyChangedInvocatorAttribute" /> class.
        /// </summary>
        public NotifyPropertyChangedInvocatorAttribute() { }

        /// <summary>
        ///     Initializes a new instance of the <see cref="NotifyPropertyChangedInvocatorAttribute" /> class.
        /// </summary>
        /// <param name="parameterName">Name of the parameter.</param>
        public NotifyPropertyChangedInvocatorAttribute(string parameterName) {
            ParameterName = parameterName;
        }

        /// <summary>
        ///     Gets the name of the parameter.
        /// </summary>
        /// <value>The name of the parameter.</value>
        [UsedImplicitly]
        public string ParameterName { get; private set; }
    }
}