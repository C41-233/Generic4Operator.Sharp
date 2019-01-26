using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Numerics;
using System.Runtime.InteropServices;
using Generic4Operator;
using Test.Types;

namespace TestMain
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Ops.Add<MyInt, BigInteger, int>(new MyInt(1), new BigInteger(1)));
        }

    }
}
