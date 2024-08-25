using System.Collections.Generic;
using System;
namespace Delegates { 
public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public int Salary { get; set; }
    public int DebtId { get; set; }
    public override string ToString()
    {
        return $"Emp id is {Id} and name is {Name} and age is {Age} and salary is {Salary} and dept {DebtId}";
    }
}
    public delegate bool MyDelegate(Employee emp);

    public class Program
{
        public static List<Employee> FilterList(MyDelegate del, List<Employee> emps)
        {
            List<Employee> newList = new List<Employee>();
            for (int i = 0; i < emps.Count; i++)
            {
                if (del(emps[i])) newList.Add(emps[i]);
            }
            return newList;
        }

        public static List<Employee> FilterListWithDefault(Func<Employee, bool> del, List<Employee> emps)
        {
            List<Employee> newList = new List<Employee>();
            for (int i = 0; i < emps.Count; i++)
            {
                if (del(emps[i])) newList.Add(emps[i]);
            }
            return newList;
        }

        public static void Main()
    {
        #region Dummy data
        List<Employee> employees = new List<Employee>()
        {
            new Employee { Id = 1, Name = "Ahmed", Age = 22, Salary = 10000, DebtId = 1 },
            new Employee { Id = 2, Name = "Basma", Age = 24, Salary = 12000, DebtId = 1 },
            new Employee { Id = 3, Name = "Sara", Age = 25, Salary = 11000, DebtId = 1 },
            new Employee { Id = 4, Name = "Sayed", Age = 27, Salary = 14000, DebtId = 2 },
            new Employee { Id = 5, Name = "Mohamed", Age = 28, Salary = 15000, DebtId = 2 },
            new Employee { Id = 6, Name = "Sally", Age = 23, Salary = 17000, DebtId = 1 },
            new Employee { Id = 7, Name = "Ali", Age = 24, Salary = 18000, DebtId = 3 },
            new Employee { Id = 8, Name = "Zyad", Age = 30, Salary = 19000, DebtId = 3 },
            new Employee { Id = 9, Name = "Raouf", Age = 29, Salary = 13000, DebtId = 3 },
            new Employee { Id = 10, Name = "Reda", Age = 21, Salary = 20000, DebtId = 4 },
            new Employee { Id = 11, Name = "Doaa", Age = 20, Salary = 18000, DebtId = 4 },
            new Employee { Id = 12, Name = "Eyad", Age = 28, Salary = 18000, DebtId = 4 },
            new Employee { Id = 13, Name = "Karim", Age = 26, Salary = 12000, DebtId = 2 },
            new Employee { Id = 14, Name = "Hala", Age = 23, Salary = 15000, DebtId = 3 },
            new Employee { Id = 15, Name = "Tarek", Age = 28, Salary = 18000, DebtId = 4 },
            new Employee { Id = 16, Name = "Amina", Age = 25, Salary = 11000, DebtId = 1 },
            new Employee { Id = 17, Name = "Youssef", Age = 27, Salary = 14000, DebtId = 2 },
            new Employee { Id = 18, Name = "Mona", Age = 24, Salary = 17000, DebtId = 3 },
            new Employee { Id = 19, Name = "Omar", Age = 29, Salary = 19000, DebtId = 4 },
            new Employee { Id = 20, Name = "Samir", Age = 22, Salary = 13000, DebtId = 1 },
        };
            #endregion

            Console.WriteLine("The Original list:");
            for (int i = 0; i < employees.Count; i++)
            {
                Console.WriteLine(employees[i]);
            }

            MyDelegate NoOlderThan25 = x => x.Age < 26;
            List<Employee> employees1 = FilterList(NoOlderThan25, employees);
            
            Console.WriteLine("Modified list(all younger than 26):");
            for (int i = 0; i < employees1.Count; i++)
            {
                Console.WriteLine(employees1[i]);
            }
            Func<Employee, bool> func = x => x.Salary <15000 ;

            List<Employee> employees2 = FilterListWithDefault(func, employees);
            Console.WriteLine("Other Modified list(all get less than 15k):");
            for (int i = 0; i < employees2.Count; i++)
            {
                Console.WriteLine(employees2[i]);
            }
        }
    }
}