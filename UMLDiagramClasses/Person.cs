using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMLDiagramClasses
{
    //this is the parent class to staff and student classes and contains public methods to call private properties, as well as a method to return
    //a string of information for a person back to the Program class
    public class Person
    {
        public Person(string name, string address)
        {
            Name = name;
            Address = address;
        }

        private string Name { get; set; }
        private string Address { get; set; }

        public virtual string ToString()
        {
            return $"Person[name = {Name}, address = {Address}]";
        }

        public string GetName()
        {
            return Name;
        }

        public string GetAddress()
        {
            return Address;
        }
    }
}
