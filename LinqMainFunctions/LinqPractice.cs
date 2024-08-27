using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqPractice
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Salary { get; set; }
        public int DeptId { get; set; }

        public override string ToString()
        {
            return "ID: " + Id + ", Name: " + Name + ", Age: " + Age + ", Salary: " + Salary + ", DeptID: " + DeptId;
        }
    }

    public class Department
    {
        public int Id { get; set; }
        public string DeptName { get; set; }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            #region Data
            List<int> numbers = new List<int>
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18
            };

            List<Student> students = new List<Student>()
            {
                new Student { Id = 1, Name = "Alice", Age = 22, Salary = 1500, DeptId = 1 },
                new Student { Id = 2, Name = "Bob", Age = 23, Salary = 1200, DeptId = 2 },
                new Student { Id = 3, Name = "Charlie", Age = 24, Salary = 1700, DeptId = 1 },
                new Student { Id = 4, Name = "David", Age = 25, Salary = 1400, DeptId = 2 },
                new Student { Id = 5, Name = "Eve", Age = 21, Salary = 1300, DeptId = 3 },
                new Student { Id = 6, Name = "Frank", Age = 23, Salary = 1600, DeptId = 1 },
                new Student { Id = 7, Name = "Grace", Age = 24, Salary = 1800, DeptId = 3 },
                new Student { Id = 8, Name = "Hank", Age = 22, Salary = 1100, DeptId = 2 }
            };

            List<Department> departments = new List<Department>()
            {
                new Department { Id = 1, DeptName = "Computer Science" },
                new Department { Id = 2, DeptName = "Mathematics" },
                new Department { Id = 3, DeptName = "Physics" }
            };
            #endregion

            #region on data of numbers:
            Console.WriteLine("\nTask 1\n");
            Console.WriteLine(numbers.FirstOrDefault());
            Console.WriteLine(numbers.LastOrDefault());
            Console.WriteLine("\nTask 2\n");
            Console.WriteLine("Min: " + numbers.Min());
            Console.WriteLine("Max: " + numbers.Max());
            Console.WriteLine("Average: " + numbers.Average());
            Console.WriteLine("\nTask 3\n");
            var x = numbers.Skip(5);
            Console.WriteLine("Numbers are as follow:");
            foreach(var i in x)
                Console.WriteLine(i);
            Console.WriteLine("\nTask 4\n");
            var y = numbers.Skip(6).Take(6);
            Console.WriteLine("Numbers are as follow:");
            foreach (var i in y)
                Console.WriteLine(i);
            #endregion

            #region on students and sections
            Console.WriteLine("Task 1 \n");
            Console.WriteLine(students.FirstOrDefault());
            Console.WriteLine(students.LastOrDefault());
            Console.WriteLine("\nTask2 \n");
            double Average = students.Average(a => a.Salary);
            Console.WriteLine("Min: " + students.Where(a=>a.Salary>Average).Min(a => a.Salary));
            Console.WriteLine("Max: " + students.Where(a => a.Salary > Average).Max(a => a.Salary));
            Console.WriteLine("Average: " + students.Where(a => a.Salary > Average).Average(a => a.Salary));
            Console.WriteLine("\n Task 3 \n");
            var list = students.OrderByDescending(a => a.Salary).Select(a => new { StudentName = a.Name, StudentSalary = a.Salary });
            var student1 = list.First();
            var Student2 = list.Skip(1).First();
            Console.WriteLine(student1.StudentName + " " + student1.StudentSalary );
            Console.WriteLine(Student2.StudentName + " " + Student2.StudentSalary);
            Console.WriteLine("\n Task 4 \n");
            var ListOfStudents = students.Join(departments, a=>a.DeptId, a=>a.Id, (a,b)=> new {Name = a.Name, department = b.DeptName});
            foreach (var student in ListOfStudents)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine("\n Task 5 \n");
            var ListX = ListOfStudents.GroupBy(a => a.department);
            foreach (var Group in ListX)
            {
                Console.WriteLine("Group Name: " + Group.Key);
                foreach (var Student in Group)
                { Console.WriteLine(Student.Name); }
            }            
            #endregion
        }
    }
}
