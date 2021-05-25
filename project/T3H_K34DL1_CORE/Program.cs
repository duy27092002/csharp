using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3H_K34DL1_CORE
{
    class Program
    {
        static void Main(string[] args)
        {
            //Đề bài
            //Viết chương trình nhập vào n laptop (0<n<=50).
            //1. Viết phương thức nhập thông tin laptop.
            //2. Viết phương thức hiển thị thông tin các laptop được nhập.
            //3. Sắp xếp laptop theo các thuộc tính bao gồm: name, weight, height

            int n = 0;
            Laptop[] laptops = new Laptop[50];

            bool flag = true;

            do
            {
                flag = true;

                Console.Write("Nhap vao so luong laptop: ");

                if (!int.TryParse(Console.ReadLine(), out n))
                {
                    Console.WriteLine("n phai la 1 so, vui long nhap lai!");
                    flag = false;
                }
                else
                {
                    if (n < 1 || n > 50)
                    {
                        Console.WriteLine("n phai nam trong doan tu 1 den 50, vui long nhap lai!");
                        flag = false;
                    }
                }
            } while (!flag);

            NhapLaptop(laptops, n);
            HienThiDS(laptops, n);
            SapXepTheoTen(laptops, n);
            HienThiDS(laptops, n);

            Console.ReadKey();
        }

        private static void NhapLaptop(Laptop[] laptops, int n)
        {
            for (int i = 0; i < n; i++)
            {
                laptops[i] = new Laptop();

                Console.WriteLine("Nhap thong tin cua laptop thu {0}", i + 1);
                Console.Write("Ten may: ");
                laptops[i].Name = Console.ReadLine();
                Console.Write("Mau sac: ");
                laptops[i].Color = Console.ReadLine();
                Console.Write("Can nang: ");
                laptops[i].Weight = float.Parse(Console.ReadLine());
                Console.Write("Dai: ");
                laptops[i].Height = float.Parse(Console.ReadLine());
                Console.Write("Rong: ");
                laptops[i].Width = float.Parse(Console.ReadLine());
                Console.Write("Kich thuoc man: ");
                laptops[i].SizeScreen = float.Parse(Console.ReadLine());
                Console.Write("Nha san xuat: ");
                laptops[i].Origin = Console.ReadLine();
                Console.Write("Thuong hieu: ");
                laptops[i].Brand = Console.ReadLine();
            }
        }

        private static void HienThiDS(Laptop[] laptops, int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Tên máy: {0}", laptops[i].Name);
            }
        }

        private static void XacDinhMua()
        {
            int month = 0;

            bool flag = true;

            do
            {
                flag = true;

                Console.Write("Nhap vao thang ma can tim mua: ");

                if (!int.TryParse(Console.ReadLine(), out month))
                {
                    Console.WriteLine("Thang phai la 1 so, vui long nhap lai!");
                    flag = false;
                }
                else
                {
                    if (month < 1 || month > 12)
                    {
                        Console.WriteLine("Thang phai nam trong doan tu 1 den 12, vui long nhap lai!");
                        flag = false;
                    }
                }
            } while (!flag);

            string session = "";
            switch (month)
            {
                case 1:
                case 2:
                case 3:
                    session = "Xuan";
                    break;
                case 4:
                case 5:
                case 6:
                    session = "Ha";
                    break;
                case 7:
                case 8:
                case 9:
                    session = "Thu";
                    break;
                case 10:
                case 11:
                case 12:
                    session = "Dong";
                    break;
            }

            Console.WriteLine("Thang {0} thuoc mua {1}", month, session);
        }

        private static void SapXepTheoTen(Laptop[] laptops, int n)
        {
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (laptops[i].Name.CompareTo(laptops[j].Name) > 0)
                    {
                        Laptop laptop = laptops[i];

                        laptops[i] = laptops[j];
                        laptops[j] = laptop;
                    }
                }
            }
        }
    }
}
