using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAppWinform.Chuong3
{
    public class BTChuon3
    {
        // Viết chương trình nhập số nguyên dương n và tính. Tính tổng các số từ 1 đến n
        public void B1()
        {
            Console.OutputEncoding = Encoding.UTF8;

            uint n, i;
            ulong sum = 0;
            bool flag = true;
            do
            {
                flag = true;
                Console.Write("Nhấp số nguyên dương lớn hơn 1: n = ");

                if (!uint.TryParse(Console.ReadLine(), out n)) flag = false;

                if (!flag || n == 0) Console.WriteLine("Hãy nhập lại theo yêu cầu!!!!");

            } while (!flag || n == 0);

            for(i = 1; i <= n; i++)
            {
                sum += i;
            }

            Console.WriteLine("Tổng các số từ 1 đến {0} là {1}", n, sum);
        }

        /*Hoán vị 2 số nguyên a, b cho trước. Đánh giá kết quả khi
            viết chương trình với hai trường hợp sau
            1. Trường hợp không dùng tham chiếu
            2. Trường hợp dùng tham chiếu: ref
         */

        //1. Trường hợp không dùng tham chiếu
        public void B2_1(int a, int b)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Trước hoán vị: a = {0}, b = {1}", a, b);

            int temp = a;
            a = b;
            b = temp;
            Console.WriteLine("Trong hoán vị: a = {0}, b = {1}", a, b);
        }

        //2. Trường hợp dùng tham chiếu: ref
        public void B2_2(ref int a, ref int b)
        {
            Console.OutputEncoding = Encoding.UTF8;
            int temp = a;
            a = b;
            b = temp;
            Console.WriteLine("Trong hoán vị: a = {0}, b = {1}", a, b);
        }

        // viết chương trình sử dụng tham chiếu out tính tổng hai số nguyên nhập vào từ bàn phím
        public void B3(out int a, out int b)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.Write("Nhập số nguyên a = ");
            a = int.Parse(Console.ReadLine());
            Console.Write("Nhập số nguyên b = ");
            b = int.Parse(Console.ReadLine());

            Console.WriteLine("Tổng hai số {0} và {1} là {2}", a, b, a + b);
        }

        // đếm số mèo sử dụng biến tĩnh
        private int height;
        private int weight;
        public int Height { get; set; }
        public int Weight { get; set; }

        public static int Count = 0;

        public BTChuon3()
        {
            height = 100;
            weight = 10;
            Count++;
        }

        // ứng dụng phương tĩnh để tính lũy thừa
        public static long GetExponentiation(int a, int n)
        {
            long result = 1;

            for(int i = 0; i < n; i++)
            {
                result *= a;
            }

            return result;
        }
    }

    /* 1. Xây dựng lớp Số phức gồm:
             - Các thuộc tính: thuc và ao là 2 số thực
             - Các phương thức:
                 + Phương thức khởi tạo không tham số để khởi tạo giá trị 0 cho phần
                thực và phần ảo
                 + Phương thức khởi tạo 2 tham số để khởi tạo giá trị cho phần thực
                và phần ảo
                 + Hàm Plus() để cộng 1 số phức với 1 số phức
                 + Hàm Plus() để cộng 1 số phức với 1 số thực
                 + Hàm Show() để in 1 số phức theo dạng (thuc, ao)
            2. Sau đó cho khai báo và khởi tạo 2 số phức x, y và
            nhập vào 1 số thực t. Tính và in ra x+y, x+t
         */
    public class ComplexNumbers
    {
        /// <summary>
        /// Ví dụ về nạp chồng phương thức và nạp chồng toán tử
        /// </summary>

        public double TheRealPart, VirtualPart;

        // hàm khởi tạo không có tham số
        public ComplexNumbers()
        {
            TheRealPart = VirtualPart = 0;
        }

        // hàm khởi tạo có tham số
        public ComplexNumbers(double t, double a)
        {
            TheRealPart = t;
            VirtualPart = a;
        }

        // hàm cộng 2 số phức
        public static ComplexNumbers Plus(ComplexNumbers x, ComplexNumbers y)
        {
            ComplexNumbers result = new ComplexNumbers();
            result.TheRealPart = x.TheRealPart + y.TheRealPart;
            result.VirtualPart = x.VirtualPart + y.VirtualPart;
            return result;
        }

        // hàm cộng số phức với số thực
        public static ComplexNumbers Plus(ComplexNumbers x, double t)
        {
            ComplexNumbers result = new ComplexNumbers();
            result.TheRealPart = x.TheRealPart + t;
            result.VirtualPart = x.VirtualPart;
            return result;
        }

        public static ComplexNumbers operator +(ComplexNumbers x, ComplexNumbers y)
        {
            ComplexNumbers result = new ComplexNumbers();
            result.TheRealPart = x.TheRealPart + y.TheRealPart;
            result.VirtualPart = x.VirtualPart + y.VirtualPart;
            return result;
        }

        // hàm cộng số phức với số thực
        public static ComplexNumbers operator +(ComplexNumbers x, double t)
        {
            ComplexNumbers result = new ComplexNumbers();
            result.TheRealPart = x.TheRealPart + t;
            result.VirtualPart = x.VirtualPart;
            return result;
        }

        // hàm in ra kết quả
        public void Show()
        {
            Console.WriteLine("({0}, {1})", TheRealPart, VirtualPart);
        }
    }
}
