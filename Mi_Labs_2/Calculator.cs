using System.Numerics;

namespace Mi_Labs_2
{
    public sealed class Calculator<T> where T : INumber<T>
    {
        public delegate T Operation(T a, T b);

        public T Add(T a, T b) => Calculator<T>.OperationMethod(a, b, (x, y) => x + y);
        public T Subtract(T a, T b) => Calculator<T>.OperationMethod(a, b, (x, y) => x - y);
        public T Multiply(T a, T b) => Calculator<T>.OperationMethod(a, b, (x, y) => x * y);
        public T Divide(T a, T b) => Calculator<T>.OperationMethod(a, b, (x, y) => x / y);

        private static T OperationMethod(T a, T b, Operation operation) => operation(a, b);
    }
}