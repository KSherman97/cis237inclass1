using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237Inclass1
{
    class Program
    {
        static void Main(string[] args)
        {

            Employee myEmployee = new Employee(); // references the default constructor of the Employee class
            
            //myEmployee.FirstNameString = "Kyle";
            //myEmployee.LastNameString = "Sherman";
            //myEmployee.WeeklySalaryDecimal = 3000m;

            // Console.WriteLine("         Name: " + myEmployee.FirstNameString + " " + myEmployee.LastNameString + "\n" + "Weekly Salary: " + myEmployee.WeeklySalaryDecimal.ToString("C"));
            //Console.WriteLine("         Name: " + myEmployee + "\n" + "Weekly Salary: " + myEmployee.WeeklySalaryDecimal.ToString("C"));
            // Console.WriteLine(myEmployee); // prints out the class name

            Employee[] employees = new Employee[10]; // create an array of 10 indexes

            employees[0] = new Employee("James", "Cameron", 1200m); // index 1
            employees[1] = new Employee("Seba", "Weber", 5000m);    // index 2
            employees[2] = new Employee("John", "Hampton", 5000m);  // index 3
            employees[3] = new Employee("RIP", "Harambe", 2500m);   // index 4
            employees[4] = new Employee("James", "Kirk", 1500.25m); // index 5
            
            

            UserInterface UI = new UserInterface();
            int choice = UI.GetUserInput();

            while (choice != 2)
            {
                if (choice == 1)
                {
                    Console.Clear();
                    string allOutPut = "";
                    foreach (Employee employee in employees) // foreach(Employee(Type;like int) employee(pointer to Employee class) in employees(array))
                    {
                        if (employee != null)
                        {
                            allOutPut += employee.ToString() + " " +
                                employee.YearlySalary().ToString("c") + Environment.NewLine;
                            //Console.WriteLine("         Name: " + employee + "\n" + "YearlySalary: " + employee.YearlySalary().ToString("C"));
                        }
                    }
                    UI.PrintAllOutput(allOutPut);
                }
                Console.WriteLine("Press any Key to continue.");
                Console.ReadKey();
                Console.Clear();
                choice = UI.GetUserInput();
            }

        }
    }
}