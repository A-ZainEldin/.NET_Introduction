using System;
using System.ComponentModel;
using System.Numerics;
using namespace1;
namespace namespace1
{
    
    class Program
    {
        public static T Total<T>(T x, T y) where T : INumber<T>
        {
            return x + y;
        }
        public static void Main(string[] args)
        {
            double x = 100.5;
            double y = 1.7;
            Console.WriteLine(Total(x, y));
            int a = 100;
            int b = 1;
            Console.WriteLine(Total(a, b));
        }
    }
}