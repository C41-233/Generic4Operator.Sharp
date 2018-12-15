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
            Console.WriteLine(Ops.Index<int[], int, int>(new int[] {1, 2}, 1));
        }
    }
}
