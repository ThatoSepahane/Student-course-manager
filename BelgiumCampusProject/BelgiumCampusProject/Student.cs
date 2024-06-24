using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelgiumCampusProject
{
    internal class Student
    {
        internal int StudentNumber { get; set; }
        internal string Name { get; set; }
        internal string Surname { get; set; }
        internal Object Image { get; set; }
        internal DateTime DateOfBirth { get; set; }
        internal  string Gender { get; set; }
        internal string Phone { get; set; }
        internal string Address { get; set; }

        internal string CourseCode { get; set; }

        public Student() { }
    }
}
