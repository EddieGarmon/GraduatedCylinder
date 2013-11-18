using System;
using System.Collections.Generic;
using System.Diagnostics;
using JetBrains.Annotations;

namespace GraduatedCylinder
{
    internal static class Guard
    {
        [DebuggerStepThrough]
        [ContractAnnotation("value:null => halt")]
        public static void NotNull<T>(T value, [NotNull] [InvokerParameterName] string name) {
            if (value != null) {
                return;
            }
            Debugger.Break();
            throw NullException(name);
        }

        [DebuggerStepThrough]
        [ContractAnnotation("value:null => halt")]
        public static void NotNullOrEmpty(string value, [NotNull] [InvokerParameterName] string name) {
            NotNull(value, name);
            if (value.Length == 0) {
                throw EmptyException(name);
            }
        }

        [DebuggerStepThrough]
        [ContractAnnotation("value:null => halt")]
        public static void NotNullOrEmpty<T>(IEnumerable<T> value, [NotNull] [InvokerParameterName] string name) {
            NotNull(value, name);
            using (IEnumerator<T> enumerator = value.GetEnumerator()) {
                if (!enumerator.MoveNext()) {
                    throw EmptyException(name);
                }
            }
        }

        [DebuggerStepThrough]
        [ContractAnnotation("value:null => halt")]
        public static void NotNullOrWhitespace(string value, [NotNull] [InvokerParameterName] string name) {
            NotNull(value, name);
            if (value.Length == 0) {
                throw EmptyException(name);
            }
        }

        private static Exception EmptyException(string name) {
            return new Exception(name + " cannot be empty.");
        }

        private static Exception NullException(string name) {
            return new Exception(name + " is null");
        }
    }
}