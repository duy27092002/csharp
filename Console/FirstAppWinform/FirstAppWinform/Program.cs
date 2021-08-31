using FirstAppWinform.Chuong3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAppWinform
{
    class Program
    {
        /*static void HoanVi(ref int a,ref int b)
        {
            int tam = a;
            a = b;
            b = tam;
            Console.WriteLine("Trong HoanVi: a = " + a + ";b = " + b);
        }*/
        static void Main(string[] args)
        {
            #region
            /*int a = 5, b = 21;
            Console.WriteLine("Truoc HoanVi: a = {0}; b = {1}", a, b);
            HoanVi(ref a,ref b);
            Console.WriteLine("Sau HoanVi: a = " + a + ";b = " + b);*/
            #endregion

            #region
            /*int n;
            do
            {
                Console.Write("Nhap so luong phan tu cua mang (n > 0): n = ");
                n = Convert.ToInt32(Console.ReadLine());
            } while (n <= 0);
            Int16[] arr = new Int16[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write("A[{0}] = ", i + 1);
                arr[i] = Int16.Parse(Console.ReadLine());
            }

            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += arr[i];
            }

            Console.WriteLine("Tong cua day so la: {0}", sum);*/
            #endregion

            //TimSoLonNhat(1, 9, -50);

            #region Chuong2
            BTChuong2 bTChuong2 = new BTChuong2();

            #region B1
            /*bTChuong2.B1();*/
            #endregion

            #region B2
            /*bTChuong2.B2();*/
            #endregion

            #region B3
            /*bTChuong2.B3();*/
            #endregion

            #region B4
            /*bTChuong2.B4();*/
            #endregion

            #region B5
            /*bTChuong2.B5();*/
            #endregion

            #region B6
            /*bTChuong2.B6();*/
            #endregion

            #region B7
            /*bTChuong2.B7();*/
            #endregion

            #region B8
            /*bTChuong2.B8();*/
            #endregion
            #endregion

            #region Chuong3
            /*Point point = new Point();
            point.Input();
            point.Show();
            point.Move(10, 20);
            point.Show();*/

            /*Divisor divisor = new Divisor();
            divisor.Input();
            divisor.GetDivisors();*/

            Console.OutputEncoding = Encoding.UTF8;

            #region B1
            /*BTChuon3 bTChuon3 = new BTChuon3();
             * bTChuon3.B1();*/
            #endregion

            #region B2_1
            /*BTChuon3 bTChuon3 = new BTChuon3();
             * int a = 10, b = 11;
            bTChuon3.B2_1(a, b);
            Console.WriteLine("Sau hoán vị: a = {0}, b = {1}", a, b);*/
            #endregion

            #region B2_2
            /*BTChuon3 bTChuon3 = new BTChuon3();
             * int a = 10, b = 11;
            Console.WriteLine("Trước hoán vị: a = {0}, b = {1}", a, b);
            bTChuon3.B2_2(ref a, ref b);
            Console.WriteLine("Sau hoán vị: a = {0}, b = {1}", a, b);*/
            #endregion

            #region B3
            /*BTChuon3 bTChuon3 = new BTChuon3();
             * int a, b;
            bTChuon3.B3(out a, out b);*/
            #endregion

            #region B4 đếm mèo
            /*Console.WriteLine("Ban đầu số mèo là: {0}", BTChuon3.Count);

            BTChuon3 BlackCat = new BTChuon3();
            Console.WriteLine("Sau khi thêm mèo đen thì số mèo hiện tại là: {0}", BTChuon3.Count);

            BTChuon3 WhiteCat = new BTChuon3();
            Console.WriteLine("Sau khi thêm tiếp mèo trắng thì số mèo hiện tại là: {0}", BTChuon3.Count);*/
            #endregion

            #region Tính lũy thừa
            //Console.WriteLine("Kết quả của 2^0 = {0}", BTChuon3.GetExponentiation(2, 0));
            #endregion

            #region Số phức
            /*ComplexNumbers x = new ComplexNumbers(5, -5);
            ComplexNumbers y = new ComplexNumbers(10, -10);

            Console.WriteLine("Ta có số phức x dạng (5, -5) và y dạng (10, -10)");

            ComplexNumbers z = new ComplexNumbers();

            // sử dụng chồng phương thức
            *//*z = ComplexNumbers.Plus(x, y);*//*

            // sử dụng chồng toán tử
            z = x + y;

            Console.Write("Phép cộng 2 số phức x và y là: ");
            z.Show();

            double t;
            Console.Write("Nhập 1 số thực bất kỳ: t = ");
            t = double.Parse(Console.ReadLine());

            *//*z = ComplexNumbers.Plus(x, t);*//*

            z = x + t;

            Console.Write("Phép cộng 2 số phức x và t là: ");
            z.Show();*/
            #endregion

            #region Kế thừa
            /*HinhVuong hinhVuong = new HinhVuong(10);
            Console.WriteLine(hinhVuong.DienTich());*/

            /*Animal animal = new Animal();
            animal.Sound();

            Dog dog = new Dog();
            dog.Sound();*/
            #endregion

            #region Đa hình
            //cách 1
            /*List<Hinh> hinhs = new List<Hinh>();
            hinhs.Add(new HinhChuNhat(10, 20));
            hinhs.Add(new HinhTron(2));

            foreach(var hinh in hinhs)
            {
                Console.WriteLine("S = {0}", hinh.DienTich());
            }*/

            // cách 2
            /*HinhChuNhat hinhChuNhat = new HinhChuNhat(10, 20);
            HinhTron hinhTron = new HinhTron(2);
            Console.WriteLine("S = {0}", hinhChuNhat.DienTich());
            Console.WriteLine("S = {0}", hinhTron.DienTich());*/
            #endregion

            #region BT Cuối Chương - Tính lương của nhân viên BC và nhân viên HD
            Nguoi[] nguois = new Nguoi[99];
            string loai;
            char chon;
            int N = 0, i;

            do
            {
                Console.WriteLine("Bạn là nhân viên biên chế(BC) hay nhân viên hợp đồng(HD)?");
                Console.WriteLine("Nếu theo biên chế thì gõ 'BC', nếu theo hợp đồng thì gõ 'HD'.");
                loai = Console.ReadLine();

                if (loai == "BC")
                {
                    BC bC = new BC();
                    bC.Nhap();
                    nguois[N++] = bC;
                }
                else if (loai == "HD")
                {
                    HD hD = new HD();
                    hD.Nhap();
                    nguois[N++] = hD;
                }

                Console.WriteLine("Bạn có muốn nhập tiếp hay không? Vui lòng gõ 'c' nếu muốn, ngược lại gõ 'k'");
                chon = char.Parse(Console.ReadLine());

                if (chon == 'k' || chon == 'K' || N > 99) break;

            } while (true);

            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("Đây là danh sách lương: \n-------------------------------------------------------------------------------");

            for (i = 0; i < N; i++)
            {
                nguois[i].Xuat();
                Console.WriteLine("-------------------------------------------------------------------------------");
            }
            #endregion

            #region Static
            /*Point point0 = new Point();
            Point point1 = new Point();

            Console.WriteLine("Dynamic");

            Console.WriteLine("Before:");

            point0.NameDynamic = "0";
            point1.NameDynamic = "1";
            Console.WriteLine("Dynamic 0 = {0}, Dynamic 1 = {1}", point0.NameDynamic, point1.NameDynamic);

            Console.WriteLine("After:");

            point0.NameDynamic = "00";
            //point1.NameDynamic = "11";
            Console.WriteLine("Dynamic 0 = {0}, Dynamic 1 = {1}", point0.NameDynamic, point1.NameDynamic);

            Console.WriteLine("Static");

            Console.WriteLine("Before:");

            point0.NameStatic = "ABC";
            Console.WriteLine("Static 0 = {0}, Static 1 = {1}", point0.NameStatic, point1.NameStatic);

            Console.WriteLine("After:");

            point1.NameStatic = "New change";
            Console.WriteLine("Static 0 = {0}, Static 1 = {1}", point0.NameStatic, point1.NameStatic);*/

            #endregion

            #region Interface
            /*IDongVatTrenCan conEch = new ConEch();
            conEch.Nhay();*/
            #endregion

            #endregion

        }

        private static void TimSoLonNhat(int a, int b, int c)
        {
            if (a > b && a > c)
            {
                Console.WriteLine("{0} la so lon nhat", a);
            } else if (b > a && b > c)
            {
                Console.WriteLine("{0} la so lon nhat", b);
            } else
            {
                Console.WriteLine("{0} la so lon nhat", c);
            }
        }
    }
}
