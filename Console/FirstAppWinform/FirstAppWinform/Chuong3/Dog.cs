using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAppWinform.Chuong3
{
    public class Dog : Animal
    {
        public Dog()
        {
            Console.WriteLine("Dog constructor!");
        }
        public new void Sound()
        {
            Console.WriteLine("Dog sound: go go go");
        }
    }
}
