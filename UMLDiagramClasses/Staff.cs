using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMLDiagramClasses
{
    //this is a child class of Person class that contains an override method to return the string of information for staff back to the Program class
    public class Staff : Person
    {
        public Staff(string name, string address, string school, double pay) : base(name, address)
        {
            School = school;
            Pay = pay;
        }

        private string School { get; set; }
        private double Pay { get; set; }

        public override string ToString()
        {
            return $"Staff[Person[name= {GetName()}, address= {GetAddress()}], school= {School}, pay= {Pay}]";
        }
    }
}
