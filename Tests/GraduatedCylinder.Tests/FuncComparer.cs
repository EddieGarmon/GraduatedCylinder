using System;
using System.Collections.Generic;

namespace GraduatedCylinder
{
    public class FuncComparer<T> : IComparer<T>,
                                   IEqualityComparer<T>
    {
        private readonly Func<T, T, int> _compare;

        public FuncComparer(Func<T, T, int> comparer) {
            _compare = comparer;
        }

        public int Compare(T x, T y) {
            return _compare(x, y);
        }

        public bool Equals(T x, T y) {
            return (_compare(x, y) == 0);
        }

        public int GetHashCode(T obj) {
            return obj.GetHashCode();
        }
    }
}