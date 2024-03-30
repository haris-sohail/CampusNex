using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusNex.Model
{
    internal class Student : User
    {
        // Properties specific to Student
        public int StudentId { get; set; }
        public string RollNo { get; set; }

        // Constructor
        public Student()
        {
            // Default constructor
        }

        // Methods
        // Other methods specific to Student can be added here

        // Method to register for a society
        public void RegisterSociety(object society)
        {
            // Implement society registration logic here
        }
    }
}
