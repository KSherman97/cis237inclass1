using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237Inclass1
{
    class UserInterface
    {
        // UserInterface is a service class
        public int GetUserInput()
        {
            this.printMainMenu();

            string input = Console.ReadLine();

            while(input != "1" && input != "2")
            {
                Console.Clear();
                Console.WriteLine("That is not a valid input!");
                Console.WriteLine("Please try again.");
                Console.WriteLine();

                System.Threading.Thread.Sleep(2000);
                Console.Clear();

                this.printMainMenu();
                input = Console.ReadLine();
                
            }
            return Int32.Parse(input);
        }

        public void PrintAllOutput(string allOutput)
        {
            Console.WriteLine(allOutput);
        }

        private void printMainMenu()
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Print List");
            Console.WriteLine("2. Exit");
        }

    }
}
