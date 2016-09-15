using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237Inclass1
{
    // add static keyword to make this class static
    public static class StaticUserInterface
    {
        // this method has become static
        public static int GetUserInput()
        {

        // there are no backing field variables because we don't need any 
        // there are no properties because we don't have any backing fields
        // there are also no constructors. We will just use the default that is 
        // automatically provided to us.

            // this class essentially becomes a collection of methods that do work.

            // UserInterface is a service class
            // used to get user input
            StaticUserInterface.printMainMenu(); // call the printMainMenu method and qualify it using the name of this
                                                 // class instead of the keyword 'this'. It does the same thing as 'this'
                                                 // but since 'this' for instances and static classes can't have instances
                                                 // we must use the class name. 

            string input = Console.ReadLine(); // read input from the console

            // continue to loop while the input is not a valid choice
            while (input != "1" && input != "2")
            {
                // since it is not valid, output a message saying so
                Console.Clear();
                Console.WriteLine("That is not a valid input!");
                Console.WriteLine("Please try again.");
                Console.WriteLine();

                System.Threading.Thread.Sleep(2000); // 2 second pause before continuing
                Console.Clear();

                StaticUserInterface.printMainMenu(); // call the printMainMenu method that is private to this class
                input = Console.ReadLine(); // read user input

            }
            return Int32.Parse(input); // parse the input as an integer
        }

        public static void PrintAllOutput(string allOutput)
        {
            Console.WriteLine(allOutput);
        }

        private static void printMainMenu()
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Print List");
            Console.WriteLine("2. Exit");
        }
    }
    }
}