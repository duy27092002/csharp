using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAppWinform.Chuong3
{
    public class Divisor
    {
        private int n_;
        public void Input()
        {
            bool flag = true;
            do
            {
                flag = true;
                Console.Write("n = ");

                if (!int.TryParse(Console.ReadLine(), out n_)) flag = false;

                if (!flag) Console.WriteLine("The data is not in the correct format, please try again!!!");
            } while (!flag);
        }

        public void GetDivisors()
        {
            Console.WriteLine("The divisors: ");
            for (int i = 1; i <= n_; i++)
            {
                if (n_ % i == 0) Console.WriteLine(i);
            }
        }
    }
}
