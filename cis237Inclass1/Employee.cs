using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237Inclass1
{
    class Employee
    {

        // *************************************************
        //             Backing fields(Variables)
        // *************************************************
        private string _firstNameString;
        private string _lastNameString;
        private decimal _weeklySalaryDecimal;

        // *************************************************
        //                    Properties
        // *************************************************
        public string FirstNameString
        {
            get { return _firstNameString; }
            set { _firstNameString = value; }
        }

        public string LastNameString
        {
            get { return _lastNameString; }
            set { _lastNameString = value; }
        }

        public decimal WeeklySalaryDecimal
        {
            get { return _weeklySalaryDecimal; }
            set { _weeklySalaryDecimal = value; }
        }

        // *************************************************
        //                 Public Methods
        // *************************************************

        // returns the Firstname and Lastname when printing myEmployee
        public override string ToString()
        {
            return this._firstNameString + " " + this._lastNameString;
        }

        public decimal YearlySalary()
        {
            return this._weeklySalaryDecimal * 52;
        }

        // *************************************************
        //                  Constructor
        // *************************************************
        public Employee(string firstNameString, string lastNameString, decimal weeklySalaryDecimal)
        {
            this._firstNameString = firstNameString;
            this._lastNameString = lastNameString;
            this._weeklySalaryDecimal = weeklySalaryDecimal;
        }

        // Defualt Constructor
        public Employee() 
        {
            // do nothing
        }
    }
}