using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
            //employees[0] = new Employee("James", "Cameron", 1200m); // index 1
            //employees[1] = new Employee("Seba", "Weber", 5000m);    // index 2
            //employees[2] = new Employee("John", "Hampton", 5000m);  // index 3
            //employees[3] = new Employee("RIP", "Harambe", 2500m);   // index 4
            //employees[4] = new Employee("James", "Kirk", 1500.25m); // index 5


            // instantiate the CSVProcessor method that we wrote into main to load the 
            // employees from the csv file
            ImportCSV("employees.csv", employees);


            // instanciate a new UI class
            UserInterface UI = new UserInterface();

            // Static version of the UI class
            // we don't have to instantiate this class since it's static
            // it's instantiated at the beginning of the class
            //StaticUserInterface.GetUserInput();

            // get the user input from the UI class
            int choice = UI.GetUserInput();
            // int choice = StaticUserInterface.GetUserInput(); // example with using the static UI class

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

        // CSV Reader
        // dependency injection (good coding practice) https://msdn.microsoft.com/en-us/library/hh323705(v=vs.100).aspx
        static bool ImportCSV(string pathToCSVFile, Employee[] employees)
        {
            // declares a new variables for a StreamReader object. Not instantiating it yet
            StreamReader streamReader = null;// requiers: using System.IO; set default to null

            // start a try since the path to the file could be incorrect, and thus throwing an exception
            try
            {
                // Declare a string for each line we will read in
                string line;

                // instantiate the streamreader object
                streamReader = new StreamReader(pathToCSVFile);

                // initialize a counter variable to 0 for the while loop
                int counter = 0;

                // check if the file has reached a null yet
                // while there is a line to read, read it and put it in the line var
                while((line = streamReader.ReadLine()) != null)
                {
                    // call the process line method and send over the read in line 
                    // the employees array (which is passed by reference automatically)
                    // and the counter, which will be used as the index for the array.
                    // We are also incrementing the counter after we send it in with the ++ operator
                    processLine(line, employees, counter++);
                }
                return true; // once the end of the file has been reached, return true
            }
            catch(Exception Ex)
            {
                // if something went wrong then print it to the console
                Console.WriteLine(Ex.ToString() + Environment.NewLine + Ex.StackTrace);
                return false; // return false, stating that an exception has occured
            }
            finally // once the try / catch has completed, finish doing this stuff. Do it whether try is successful or not
            {
                // if there is a file to close then you need to close it before continuing on with the program
                if(streamReader != null) 
                {
                    streamReader.Close();
                }
            }
        }

        static void processLine(string line, Employee[] employees, int index)
        {
            // declares a string array and assigns the split line to it.
            string[] parts = line.Split(',');

            // assign the parts to local variables that mean something
            string firstName = parts[0];
            string lastName = parts[1];
            decimal salary = decimal.Parse(parts[2]);

            // Use the variables to instanciate a new employee and assign it to 
            // the spot in the employees array indexed by the index that was passed in.
            employees[index] = new Employee(firstName, lastName, salary);
        }
    }
}