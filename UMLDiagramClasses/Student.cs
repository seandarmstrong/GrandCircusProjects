using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMLDiagramClasses
{
    //this is a child class of Person class that contains an override method to return the string of information for students back to the Program class
    public class Student : Person
    {
        public Student(string name, string address, string program, int year, double fee) : base(name, address)
        {
            Program = program;
            Year = year;
            Fee = fee;

        }

        private string Program { get; set; }
        private int Year { get; set; }
        private double Fee { get; set; }

        public override string ToString()
        {
            return $"Student[Person[name= {GetName()}, address= {GetAddress()}], program= {Program}, year= {Year}, fee= {Fee}]";
        }
    }
}
