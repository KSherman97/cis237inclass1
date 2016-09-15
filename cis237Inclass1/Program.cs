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
            // Declaring a variable of type Employee (which is a class)
            // instancing a new instance of employee and assigning it to the variable
            // isomg the New keyword means that memory will get allocated on the Heap for that class
            Employee myEmployee = new Employee(); // references the default constructor of the Employee class
            
            // use the properties to assign values
            //myEmployee.FirstNameString = "Kyle";
            //myEmployee.LastNameString = "Sherman";
            //myEmployee.WeeklySalaryDecimal = 3000m;

            // output the information collected
            // Console.WriteLine("         Name: " + myEmployee.FirstNameString + " " + myEmployee.LastNameString + "\n" + "Weekly Salary: " + myEmployee.WeeklySalaryDecimal.ToString("C"));
            //Console.WriteLine("         Name: " + myEmployee + "\n" + "Weekly Salary: " + myEmployee.WeeklySalaryDecimal.ToString("C"));
            // output the entire employee, which will call the TosTring method implicitly
            // this would work even without overriding the ToString method in the Employee class,
            // however it would only spit out the namespace and name of class instead of something useful.
            // Console.WriteLine(myEmployee); // prints out the class name

            // create an array of type employee to hold a bunch of Employees
            Employee[] employees = new Employee[10]; // create an array of 10 indexes

            // assign values to the array. Each spot needs to contain an instance of an Employee
            // call the constructor of the Employee class and store the info into the array indexes
            employees[0] = new Employee("James", "Cameron", 1200m); // index 1
            employees[1] = new Employee("Seba", "Weber", 5000m);    // index 2
            employees[2] = new Employee("John", "Hampton", 5000m);  // index 3
            employees[3] = new Employee("RIP", "Harambe", 2500m);   // index 4
            employees[4] = new Employee("James", "Kirk", 1500.25m); // index 5
            
            
            // instanciate a new UI class
            UserInterface UI = new UserInterface();
            // get the user input from the UI class
            int choice = UI.GetUserInput();

            // continue until 2(exit) is entered as the menue value
            while (choice != 2)
            {
                // if the user enters the 1(print out employees) do the required work
                if (choice == 1)
                {
                    Console.Clear();
                    string allOutPut = "";
                    // a foreach loop. It is usefull for doing a collection of objects
                    // Each object in the array 'employees' will get assigned to the local variable 'employee' inside the loop
                    foreach (Employee employee in employees) // foreach(Employee(Type;like int) employee(pointer to Employee class) in employees(array))
                    {
                        // run a check to make sure the spot in the array is not empty
                        if (employee != null)
                        {
                            // print the employee
                            allOutPut += employee.ToString() + " " +
                                employee.YearlySalary().ToString("c") + Environment.NewLine;
                            //Console.WriteLine("         Name: " + employee + "\n" + "YearlySalary: " + employee.YearlySalary().ToString("C"));
                        }
                    }
                    UI.PrintAllOutput(allOutPut); // print the concatinated line of accumulated values
                }
                Console.WriteLine("Press any Key to continue.");
                Console.ReadKey(); // wait for the user to press a key
                Console.Clear();
                choice = UI.GetUserInput(); // prompt the user to enter some input again
            }

        }
    }
}