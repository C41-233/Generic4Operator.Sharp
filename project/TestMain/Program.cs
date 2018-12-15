using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Generic4Operator;
using Test.Types;

namespace TestMain
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Run(1, 2, 3));
        }

        private static T Run<T>(T a, T b, T c)
        {
            return Ops.Subtract(Ops.Add(a, b), c);
        }

    }
}
