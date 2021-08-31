using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FirstAppWinform
{
    public class BTChuong2
    {
        public void B1()
        {
            Console.OutputEncoding = Encoding.UTF8;
            int a, b, c;

            Console.Write("Nhập vào số nguyên thứ nhất: a = ");
            a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Nhập vào số nguyên thứ hai: b = ");
            b = Convert.ToInt32(Console.ReadLine());

            c = a > b ? a : b;

            Console.WriteLine("Số lớn nhất là: {0}", c);
        }

        public void B2()
        {
            Console.OutputEncoding = Encoding.UTF8;
            float a, b, c;

            Console.Write("Nhập số a = ");
            a = float.Parse(Console.ReadLine());
            Console.Write("Nhập số b = ");
            b = float.Parse(Console.ReadLine());
            Console.Write("Nhập số c = ");
            c = float.Parse(Console.ReadLine());

            if (a > b && a > c)
            {
                Console.WriteLine("Số lớn nhất là a = {0}", a);
            }
            else if (b > a && b > c)
            {
                Console.WriteLine("Số lớn nhất là b = {0}", b);
            }
            else if (c > a && c > b)
            {
                Console.WriteLine("Số lớn nhất là c = {0}", c);
            }
            else
            {
                Console.WriteLine("Không có số lớn nhất!");
            }
        }

        public void B3()
        {
            Console.OutputEncoding = Encoding.UTF8;
            try
            {
                int n, i;
                double result = 1;

                do
                {
                    Console.Write("Nhập số tự nhiên n = ");
                    n = Convert.ToInt32(Console.ReadLine());
                } while (n < 0);

                if (n == 0)
                {
                    Console.WriteLine("Kết quả: {0}! = {1}", n, result);
                }
                else
                {
                    for (i = 1; i <= n; i++)
                    {
                        result *= i;
                    }
                    Console.WriteLine("Kết quả: {0}! = {1}", n, result);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Hãy khởi động lại trương trình và nhập một số tự nhiên!");
            }
        }

        public void B4()
        {
            Console.OutputEncoding = Encoding.UTF8;
        }

        public void B5()
        {
            Console.OutputEncoding = Encoding.UTF8;

            int n, count = 1, i;
            bool flag = true;

            do
            {
                flag = true;

                Console.Write("Nhập số tự nhiên khác 0: n = ");

                if (!int.TryParse(Console.ReadLine(), out n)) flag = false;

                if (!flag || n <= 0) Console.WriteLine("Hãy nhập vào số tự nhiên lớn hơn 0. Chương trình sẽ không chấp nhận số như này: VD 10.0 hoặc 10,0");

            } while (n <= 0 || !flag);

            for (i = 1; i <= n / 2; i++)
            {
                if (n % i == 0)
                {
                    count++;
                }
            }

            Console.WriteLine("{0} có số ước là: {1}", n, count);
        }

        public void B6()
        {
            Console.OutputEncoding = Encoding.UTF8;
            
            int n, i, j;
            bool flag = true;

            do
            {
                flag = true;
                Console.Write("Nhập vào số tự nhiên lớn hơn 1: n = ");

                if (!int.TryParse(Console.ReadLine(), out n))
                {
                    flag = false;
                }

                if (!flag || n <= 1) Console.WriteLine("Hãy nhập vào 1 số tự nhiên lớn hơn 1!!!!");

            } while (n <= 1 || !flag);

            for (i = 0; i < n; i++)
            {
                for (j = 0; j <= i; j++)
                {
                    Console.Write(" * ");
                }
                Console.WriteLine();
            }
        }

        public void B7()
        {
            Console.OutputEncoding = Encoding.UTF8;

            int n, i;
            string N = "";
            bool flag = true;

            do
            {
                flag = true;

                Console.Write("Nhập số tự nhiên lớn hơn 0: n = ");
                if (!int.TryParse(Console.ReadLine(), out n))
                {
                    flag = false;
                }

                if(!flag || n <= 0)
                {
                    Console.WriteLine("Hãy nhập một số tự nhiên khác 0!");
                }

            } while (!flag || n <= 0);

            float sum = n;

            for (i = 1; i <= n / 2; i++)
            {
                flag = false;

                if (n % i == 0)
                {
                    flag = true;
                    sum += i;
                }

                if (flag) N += i + " + ";
            }
            Console.WriteLine("Tổng các ước của {0} là: {1}{2} = {3}", n, N, n, sum);

        }

        public void B8()
        {
            byte h, m, s;

            Console.OutputEncoding = Encoding.UTF8;

            Console.Write("Nhập giờ: ");
            h = byte.Parse(Console.ReadLine());
            Console.Write("Nhập số phút: ");
            m = byte.Parse(Console.ReadLine());
            Console.Write("Nhập số giây: ");
            s = byte.Parse(Console.ReadLine());

            if (h >= 24 || h < 0)
            {
                Console.WriteLine("Bạn đã nhập sai giờ!");
            }
            else if (m < 0 || m >= 60)
            {
                Console.WriteLine("Bạn đã nhập sai phút!");
            }
            else if (s < 0 || s >= 60)
            {
                Console.WriteLine("Bạn đã nhập sai giây!");
            }
            else
            {
                Console.WriteLine("Thời gian bạn vừa nhập là: {0:D2}:{1:D2}:{2:D2}", h, m, s);
            }
        }
    }
}
