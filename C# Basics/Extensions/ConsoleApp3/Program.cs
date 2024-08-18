using System;
using System.ComponentModel;
using namespace1;
namespace namespace1
{
    static class String_Extension
    {
        public static string AddStars(this string s, int numberOfStars)
        {
            for (int i = 0; i < numberOfStars; i++) s = '*' + s;
            for (int i = 0; i < numberOfStars; i++) s += '*';
            return s;
        }
    }
    class Program
    {
        
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter any string");
            string x = Console.ReadLine();
            Console.WriteLine("Enter number of stars");
            string num = Console.ReadLine();
            int z;
            if (int.TryParse(num, out z))
            {
                Console.WriteLine(x.AddStars(z));
            }
            else
            {
                Console.WriteLine("input was not an intiger");
            }

        }
    }
}