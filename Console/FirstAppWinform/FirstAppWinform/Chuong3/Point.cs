using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAppWinform
{
    public class Point
    {
        /*
         xây dựng lớp diem với các thuộc tính tung độ, hoành độ của điểm đó, phương thức đổi
        tọa độ giữa dương âm, phương thức di chuyển theo một giá trị nhập từ bàn phím, phương
        thức hiện điểm lên màn hình
         */
        private int x_;
        private int y_;

        public int X { get; set; }
        public int Y { get; set; }

        /// <summary>
        /// Dùng để thay đổi tọa độ thừ vị trí này sang vị trí khác
        /// </summary>
        /// <param name="dx">dx là khoảng cách từ x cũ đến x mới</param>
        /// <param name="dy"></param>
        public void Move(int dx, int dy)
        {
            x_ += dx; // tương đương với this.x_ = dx;
            y_ += dy;
        }

        public void Show()
        {
            Console.Write("Coordinates: (");
            Console.Write("{0}, {1}", x_, y_);
            Console.WriteLine(")");
        }

        public void Chuyen()
        {
            x_ = -x_;
            y_ = -y_;
        }

        public void Input()
        {
            Console.WriteLine("Enter your coordinates:");
            x_ = GetInput("x");
            y_ = GetInput("y");
        }

        public int GetInput(string name)
        {
            bool flag = true;
            int num;
            do
            {
                flag = true;
                Console.Write("{0} = ", name);

                if (!int.TryParse(Console.ReadLine(), out num)) flag = false;

                if (!flag) Console.WriteLine("The data is not in the correct format, please try again!!!");
            } while (!flag);

            return num;
        }

        private static string nameStatic;
        public string NameStatic
        {
            get
            {
                return nameStatic;
            }
            set
            {
                nameStatic = value;
            }
        }

        private string nameDynamic;
        public string NameDynamic 
        {
            get
            {
                return nameDynamic;
            }
            set
            {
                nameDynamic = value;
            }
        }
        
    }
}
