using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPractice_Code1_2_3.De3
{
    class Student : Person
    {
        protected string ComputerSci { get; set; }
        protected string Marketing { get; set; }
        protected string Finance { get; set; }

        public void Accept()
        {
            Console.Write("Nhap Ten: ");
            this.Name = Console.ReadLine();

            Console.Write("Nhap Email: ");
            this.Email = Console.ReadLine();

            Console.Write("Nhap Computer Sci: ");
            this.ComputerSci = Console.ReadLine();

            Console.Write("Nhap Marketing: ");
            this.Marketing = Console.ReadLine();

            Console.Write("Nhap Finance: ");
            this.Finance = Console.ReadLine();
        }

        public void Display()
        {
            Console.WriteLine("Thong tin chi tiet cua Student:");
            Console.WriteLine($"Computer Sci: {this.ComputerSci}");
            Console.WriteLine($"Marketing: {this.Marketing}");
            Console.WriteLine($"Finance: {this.Finance}\n");
        }
    }
}
