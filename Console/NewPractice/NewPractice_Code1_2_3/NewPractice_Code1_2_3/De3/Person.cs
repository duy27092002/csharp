using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPractice_Code1_2_3.De3
{
    abstract class Person
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return $"\nName: {this.Name}\nEmail: {this.Email}\n";
        }
    }
}
