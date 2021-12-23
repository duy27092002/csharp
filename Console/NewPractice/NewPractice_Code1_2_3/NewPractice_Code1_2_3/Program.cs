using NewPractice_Code1_2_3.De3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NewPractice_Code1_2_3
{
    class Program
    {
        // kiểm tra đầu vào là số
        static bool IsNumber(string input)
        {
            Regex checkNumber = new Regex(@"^[+]?[0-9]*\.?[0-9]+$");

            if (checkNumber.IsMatch(input)) return true;

            return false;
        }

        static void Main(string[] args)
        {
            #region Đề 1

            #region Bài 1

            //int total, getMinutes;
            //string getInput;

            //Console.Write("Nhap vao so phut goi: ");

            //getInput = Console.ReadLine();

            //if (!IsNumber(getInput))
            //{
            //    Console.WriteLine("Hay nhap dung so phut da goi! (khong phai chu cai hoac so < 0)");
            //}
            //else
            //{
            //    getMinutes = int.Parse(getInput);

            //    if (getMinutes > 0 && getMinutes <= 2)
            //    {
            //        Console.WriteLine("So phut goi da nhap la: {0} phut", getMinutes);

            //        Console.WriteLine("Cuoc phi phai tra la: 5 USD");
            //    }
            //    else
            //    {
            //        Console.WriteLine("So phut goi da nhap la: {0} phut", getMinutes);

            //        total = 5 + (getMinutes - 2) * 2;

            //        Console.WriteLine("Cuoc phi phai tra la: {0} USD", total);
            //    }
            //}

            #endregion

            #region Bài 2

            //int i;

            //Console.WriteLine("Day so chan tu 1 den 100 gom:");

            //for (i = 1; i <= 100; i++)
            //    if (i % 2 == 0) Console.Write("{0} ", i);

            //Console.WriteLine("\n\nDay so le tu 1 den 100 gom:");

            //for (i = 1; i <= 100; i++)
            //    if (i % 2 != 0) Console.Write("{0} ", i);

            #endregion

            #endregion

            #region Đề 2

            #region Bài 1

            //Console.Write("Nhap vao ten viet tat 3 chu cai cua thang trong Tieng Anh (VD: Jan): ");

            //string monthName = Console.ReadLine();

            //switch (monthName.ToLower())
            //{
            //    case "jan":
            //    case "feb":
            //    case "mar":
            //        {
            //            Console.WriteLine("{0} thuoc quy I", monthName);
            //            break;
            //        }
            //    case "apr":
            //    case "may":
            //    case "jun":
            //        {
            //            Console.WriteLine("{0} thuoc quy II", monthName);
            //            break;
            //        }
            //    case "jul":
            //    case "aug":
            //    case "sep":
            //        {
            //            Console.WriteLine("{0} thuoc quy III", monthName);
            //            break;
            //        }
            //    case "oct":
            //    case "nov":
            //    case "dec":
            //        {
            //            Console.WriteLine("{0} thuoc quy IV", monthName);
            //            break;
            //        }
            //    default:
            //        {
            //            Console.WriteLine("Khong nhan dien duoc ten viet tat nay!");
            //            break;
            //        }
            //}

            #endregion

            #region Bài 2

            //int i, j;

            //Console.WriteLine("Giai thua cua cac so nguyen tu 1 den 20 theo thu tu la:");

            //for (i = 1; i <= 20; i++)
            //{
            //    decimal result = 1;

            //    for (j = 1; j <= i; j++) result *= j;

            //    Console.WriteLine("{0} ", result);
            //}

            #endregion

            #region Bài 3

            //int result = 0, i;

            //for(i = 1; i <= 100; i += 2) result += i;

            //Console.WriteLine("Tong so le tu 1 den 100 la: {0}", result);

            #endregion

            #endregion

            #region Đề 3

            #region Student

            Student std = new Student();

            std.Accept();
            Console.WriteLine("\nStudent:" + std.ToString());
            std.Display();

            #endregion

            #endregion
        }
    }
}