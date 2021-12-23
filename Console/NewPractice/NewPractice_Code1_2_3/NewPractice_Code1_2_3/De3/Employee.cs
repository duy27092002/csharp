using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPractice_Code1_2_3.De3
{
    abstract class Employee : Person
    {
        protected string EmpID { get; set; }
        protected string Department { get; set; }
        public DateTime HireDate { get; set; }
    }
}
