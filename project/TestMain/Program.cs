using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Numerics;
using Generic4Operator;

namespace TestMain
{

    class Program
    {
        static void Main(string[] args)
        {
            //var watch = new Stopwatch();
            //watch.Start();
            //for (var i = 0; i < 10000000; i++)
            //{
            //    var a = new BigInteger(i);
            //    var b = new BigInteger(i+1);
            //    var c = new BigInteger(i + 2);
            //    Measure.Test_Ops(a, b, c);
            //}
            //watch.Stop();
            //Console.WriteLine(watch.ElapsedMilliseconds);

            var e = Expression.Add(
                Expression.Parameter(typeof(int)),
                Expression.Parameter(typeof(float))
            );
            Console.Write(e);
        }

    }
}
