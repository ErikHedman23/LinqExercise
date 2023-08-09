using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers
            //numbers.Sum(x => x);
            Console.WriteLine("Display the sum of the array numbers:");
            Console.WriteLine(numbers.Sum());

            //TODO: Print the Average of numbers
            Console.WriteLine("Display the average of array numbers:");
            Console.WriteLine(numbers.Average());

            //TODO: Order numbers in ascending order and print to the console
           var numAscending =  numbers.OrderBy(x => x).ToArray();
            Console.WriteLine("Numbers in Ascedning order:");
            foreach (int x in numAscending)
            {

                Console.WriteLine(x);

            }
            Console.WriteLine();
            //TODO: Order numbers in descending order and print to the console
           var numDescending =  numbers.OrderByDescending(x => x);
            Console.WriteLine("Numbers in Descending Order:");
            foreach(int x in numDescending)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine();
            //TODO: Print to the console only the numbers greater than 6
            var onlyGreaterThanSix = numbers.Where(x => x > 6);
            Console.WriteLine("Only numbers greater than six:");
            foreach(int x in onlyGreaterThanSix)
            {
                Console.WriteLine(x);
            }

            //TODO: Order numbers in any order (ascending or desc) but only print 4 of them **foreach loop only!**
            var onlyFour = numbers.OrderBy(x => x).Take(4);
            Console.WriteLine("Four numbers in ascending order and only taking 4 of them:");
            
            foreach(var num in onlyFour)
            {
                Console.WriteLine(num);
            }
            //TODO: Change the value at index 4 to your age, then print the numbers in descending order
            var changeAge = numbers.Select((num, index) => index == 4 ? 23 : num);
            Console.WriteLine("Display an updated array of numbers:");
            foreach (var num in changeAge)
            {
                Console.WriteLine(num);
            }
            //numbers = changeAge.ToArray();
            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.
            var employee = employees.Where(x => x.FirstName.ToLower().StartsWith('c') || x.FirstName.ToLower().StartsWith('s')).OrderBy(x => x.FirstName);
            foreach(var person in employee)
            {
                Console.WriteLine(person.FullName);
            }


            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            var employByAge = employees.Where(x => x.Age > 26).OrderBy(x => x.Age).ThenBy(x => x.FirstName);
            foreach(var person in employByAge)
            {
                Console.WriteLine(person.FullName);
                Console.WriteLine(person.Age);
            }
            //TODO: Print the Sum and then the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            var olderNewbies = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35);
            var sumOfExp = olderNewbies.Sum(x => x.YearsOfExperience);
            var averageOfExp = olderNewbies.Average(x => x.YearsOfExperience);
            Console.WriteLine($" The sum of the employees years of experience that have less than 10 YOE and are older than 35 is: {sumOfExp}");
            Console.WriteLine($"The average of the employees years of experience that have less than 10 YOE and are older than 35 is: {averageOfExp}");
            //TODO: Add an employee to the end of the list without using employees.Add()
            var updatedEmployees = employees.Append(new Employee("Erik", "Hedman", 23, 5));
            foreach(var person in updatedEmployees)
            {
                Console.WriteLine($"Welcome {person.FullName}!");
            }

            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
