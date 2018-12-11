using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Generic4Primitive
{
    internal static class OpsFactory
    {

        public static object CreateDefault(Type type)
        {
            if (type == typeof(byte))
            {
                return new Ops<byte>
                {
                    Add = (a, b) => (byte)(a + b),
                    AddToInt = (a, b) => a + b,
                    Subtract = (a, b) => (byte)(a - b),
                    SubtractToInt = (a, b) => a - b,
                    Increase = a => ++a,
                    IncreaseAndGet = (ref byte a) => ++a,
                    IncreaseAndGetOriginal = (ref byte a) => a++,
                    Decrease = a => --a,
                    DecreaseAndGet = (ref byte a) => --a,
                    DecreaseAndGetOriginal = (ref byte a) => a--,
                    ToInt = a => a,
                };
            }
            if (type == typeof(sbyte))
            {
                return new Ops<sbyte>
                {
                    Add = (a, b) => (sbyte)(a + b),
                    AddToInt = (a, b) => a + b,
                    Subtract = (a, b) => (sbyte)(a - b),
                    SubtractToInt = (a, b) => a - b,
                    Increase = a => ++a,
                    IncreaseAndGet = (ref sbyte a) => ++a,
                    IncreaseAndGetOriginal = (ref sbyte a) => a++,
                    Decrease = a => --a,
                    DecreaseAndGet = (ref sbyte a) => --a,
                    DecreaseAndGetOriginal = (ref sbyte a) => a--,
                    ToInt = a => a,
                };
            }

            if (type == typeof(char))
            {
                return new Ops<char>
                {
                    Add = (a, b) => (char)(a + b),
                    AddToInt = (a, b) => a + b,
                    Subtract = (a, b) => (char)(a - b),
                    SubtractToInt = (a, b) => a - b,
                    Increase = a => ++a,
                    IncreaseAndGet = (ref char a) => ++a,
                    IncreaseAndGetOriginal = (ref char a) => a++,
                    Decrease = a => --a,
                    DecreaseAndGet = (ref char a) => --a,
                    DecreaseAndGetOriginal = (ref char a) => a--,
                    ToInt = a => a,
                };
            }

            if (type == typeof(short))
            {
                return new Ops<short>
                {
                    Add = (a, b) => (short)(a + b),
                    AddToInt = (a, b) => a + b,
                    Subtract = (a, b) => (short)(a - b),
                    SubtractToInt = (a, b) => a - b,
                    Increase = a => ++a,
                    IncreaseAndGet = (ref short a) => ++a,
                    IncreaseAndGetOriginal = (ref short a) => a++,
                    Decrease = a => --a,
                    DecreaseAndGet = (ref short a) => --a,
                    DecreaseAndGetOriginal = (ref short a) => a--,
                    ToInt = a => a,
                };
            }

            if (type == typeof(ushort))
            {
                return new Ops<ushort>
                {
                    Add = (a, b) => (ushort)(a + b),
                    AddToInt = (a, b) => a + b,
                    Subtract = (a, b) => (ushort)(a - b),
                    SubtractToInt = (a, b) => a - b,
                    Increase = a => ++a,
                    IncreaseAndGet = (ref ushort a) => ++a,
                    IncreaseAndGetOriginal = (ref ushort a) => a++,
                    Decrease = a => --a,
                    DecreaseAndGet = (ref ushort a) => --a,
                    DecreaseAndGetOriginal = (ref ushort a) => a--,
                    ToInt = a => a,
                };
            }

            if (type == typeof(int))
            {
                return new Ops<int>
                {
                    Add = (a, b) => a + b,
                    AddToInt = (a, b) => a + b,
                    Subtract = (a, b) => a - b,
                    SubtractToInt = (a, b) => a - b,
                    Increase = a => ++a,
                    IncreaseAndGet = (ref int a) => ++a,
                    IncreaseAndGetOriginal = (ref int a) => a++,
                    Decrease = a => --a,
                    DecreaseAndGet = (ref int a) => --a,
                    DecreaseAndGetOriginal = (ref int a) => a--,
                    ToInt = a => a,
                };
            }

            if (type == typeof(uint))
            {
                return new Ops<uint>
                {
                    Add = (a, b) => a + b,
                    AddToInt = (a, b) => (int) (a + b),
                    Subtract = (a, b) => a - b,
                    SubtractToInt = (a, b) => (int) (a - b),
                    Increase = a => ++a,
                    IncreaseAndGet = (ref uint a) => ++a,
                    IncreaseAndGetOriginal = (ref uint a) => a++,
                    Decrease = a => --a,
                    DecreaseAndGet = (ref uint a) => --a,
                    DecreaseAndGetOriginal = (ref uint a) => a--,
                    ToInt = a => (int)a,
                };
            }

            if (type == typeof(float))
            {
                return new Ops<float>
                {
                    Add = (a, b) => a + b,
                    AddToInt = (a, b) => (int)(a + b),
                    Subtract = (a, b) => a - b,
                    SubtractToInt = (a, b) => (int)(a - b),
                    Increase = a => ++a,
                    IncreaseAndGet = (ref float a) => ++a,
                    IncreaseAndGetOriginal = (ref float a) => a++,
                    Decrease = a => --a,
                    DecreaseAndGet = (ref float a) => --a,
                    DecreaseAndGetOriginal = (ref float a) => a--,
                    ToInt = a => (int)a,
                };
            }

            if (type == typeof(double))
            {
                return new Ops<double>
                {
                    Add = (a, b) => a + b,
                    AddToInt = (a, b) => (int)(a + b),
                    Subtract = (a, b) => a - b,
                    SubtractToInt = (a, b) => (int)(a - b),
                    Increase = a => ++a,
                    IncreaseAndGet = (ref double a) => ++a,
                    IncreaseAndGetOriginal = (ref double a) => a++,
                    Decrease = a => --a,
                    DecreaseAndGet = (ref double a) => --a,
                    DecreaseAndGetOriginal = (ref double a) => a--,
                    ToInt = a => (int)a,
                };
            }

            if (type == typeof(decimal))
            {
                return new Ops<decimal>
                {
                    Add = (a, b) => a + b,
                    AddToInt = (a, b) => (int)(a + b),
                    Subtract = (a, b) => a - b,
                    SubtractToInt = (a, b) => (int)(a - b),
                    Increase = a => ++a,
                    IncreaseAndGet = (ref decimal a) => ++a,
                    IncreaseAndGetOriginal = (ref decimal a) => a++,
                    Decrease = a => --a,
                    DecreaseAndGet = (ref decimal a) => --a,
                    DecreaseAndGetOriginal = (ref decimal a) => a--,
                    ToInt = a => (int)a,
                };
            }

            if (type == typeof(string))
            {
                return new Ops<string>
                {
                    Add = (a, b) => a + b,
                    AddToInt = (a, b) => int.Parse(a + b),
                    ToInt = a => int.Parse(a),
                };
            }

            return DynamicCreateDefault(type);
        }

        private static object DynamicCreateDefault(Type type)
        {
            var opType = typeof(Ops<>).MakeGenericType(type);
            var op = Activator.CreateInstance(opType);

            var methods = type.GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.IsSpecialName).ToList();

            TryBindOperator(op, methods, "Add", "op_Addition", type, type, type);
            TryBindOperator(op, methods, "Subtract", "op_Subtraction", type, type, type);
            TryBindOperator(op, methods, "Increase", "op_Increment", type, type);
            TryBindOperator(op, methods, "Decrease", "op_Decrement", type, type);
            TryBindOperator(op, methods, "ToInt", "op_Explicit", typeof(int), type);
            TryBindOperator(op, methods, "ToInt", "op_Implicit", typeof(int), type);

            return op;
        }

        private static void TryBindOperator(object op, List<MethodInfo> methods, string fieldName, string operatorName, Type returnType, params Type[] parameterTypes)
        {
            var method = methods.Find(
                m => m.Name == operatorName
                && m.ReturnType == returnType
                && m.GetParameters().Is(parameterTypes)
            );
            if (method == null)
            {
                return;
            }
            var field = op.GetType().GetField(fieldName);
            var delegateValue = Delegate.CreateDelegate(field.FieldType, null, method);
            field.SetValue(op, delegateValue);
        }

        private static bool Is(this ParameterInfo[] parameters, params Type[] others)
        {
            if (parameters.Length != others.Length)
            {
                return false;
            }
            var len = parameters.Length;
            for (var i = 0; i < len; i++)
            {
                if (parameters[i].ParameterType != others[i])
                {
                    return false;
                }
            }
            return true;
        }

    }
}
