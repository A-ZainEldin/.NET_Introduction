using app1;
using System;
using System.Collections.Generic;

namespace app1
{
   
    class Program
    {
        public abstract class Shape
        {
            abstract public int GetArea();
        }
        public class Triangle : Shape
        {
            public int width { get; set; }
            public int height { get; set; }
            public Triangle()
            {
                width = 0;
                height = 0;
            }
            public Triangle(int width, int height)
            {
                this.width = width;
                this.height = height;
            }

            override
                public int GetArea()
            {
                return width * height / 2;
            }
        }

        public class Circle : Shape
        {
            public double radius;

            public Circle()
            {
                radius = 0;
            }

            public Circle(double radius)
            {
                this.radius = radius;
            }

            public override int GetArea()
            {
                return (int)(22 / 7 * radius * radius);
            }
        }

        public class HelloWorld
        {
            public static void Main(string[] args)
            {
                Queue<Circle> queue = new Queue<Circle>();
                bool x = true;
                while(x)
                {
                    Console.WriteLine("To add a circle, press 1.\nTo Display area and dismiss the first circle in the queue, press 2.\nTo exit, press any other key.\n");
                    string X;
                    X = Console.ReadLine();
                    if (X == "1") {
                        Console.WriteLine("Enter the radius\n");
                        double rad;
                        string input = Console.ReadLine();
                        if (double.TryParse(input, out rad))
                            queue.Enqueue(new Circle(rad));
                        else
                        {
                            Console.WriteLine("Not an acceptable number\n");
                        }
                    }
                    else if (X == "2") {
                        if(queue.Count() != 0) { 
                            Circle circle = queue.Dequeue();
                            Console.WriteLine(circle.GetArea() + "\n");
                        }
                        else Console.WriteLine("The queue is empty\n");
                    }
                    else x = false;
                }
            }
            
        }
    }
}