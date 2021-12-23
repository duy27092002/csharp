using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionHomework
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            #region Collection
            #region Bài 1

            //var bookList = new List<Book>()
            //{
            //    new Book() {Id = 1, Title = "Title 11", Author = "Author 1", Publisher = "Publisher 1", Year = "2014", Price = 100},
            //    new Book() {Id = 2, Title = "Title 12", Author = "Author 2", Publisher = "Publisher 2", Year = "2014", Price = 150},
            //    new Book() {Id = 3, Title = "Title 13", Author = "Author 3", Publisher = "Publisher 3", Year = "2015", Price = 90},
            //    new Book() {Id = 4, Title = "Title 14", Author = "Author 4", Publisher = "Nhi Dong", Year = "2015", Price = 210},
            //    new Book() {Id = 5, Title = "Title 15", Author = "Author 5", Publisher = "Nhi Dong", Year = "2014", Price = 110},
            //    new Book() {Id = 6, Title = "Title 16", Author = "Author 6", Publisher = "Nhi Dong", Year = "2016", Price = 100},
            //    new Book() {Id = 7, Title = "Title 17", Author = "Author 7", Publisher = "Publisher 7", Year = "2017", Price = 230},
            //    new Book() {Id = 8, Title = "Title 18", Author = "Author 8", Publisher = "Publisher 8", Year = "2014", Price = 300},
            //    new Book() {Id = 9, Title = "Title 19", Author = "Author 9", Publisher = "Publisher 9", Year = "2017", Price = 90},
            //    new Book() {Id = 10, Title = "Title 10", Author = "Author 10", Publisher = "Publisher 10", Year = "2020", Price = 50},

            //};

            //var getBookListByPrice = from bk in bookList
            //                         orderby bk.Price
            //                         select bk;

            //// in ra danh sách
            //Console.WriteLine("Danh sách Book sắp xếp theo thứ tự tăng dần của giá:\n");
            //foreach (Book item in getBookListByPrice)
            //{
            //    Console.Write(item.Id + "\t");
            //    Console.Write(item.Title + "\t");
            //    Console.Write(item.Author + "\t");
            //    Console.Write(item.Publisher + "\t");
            //    Console.Write(item.Year + "\t");
            //    Console.Write(item.Price + "\t");
            //    Console.WriteLine("\n");
            //}

            //// tìm kiếm theo title
            //Console.Write("Nhập Title cần tìm kiếm: ");
            //string title = Console.ReadLine();

            //var getBookListByTitle = from bk in bookList
            //                         where bk.Title.ToLower() == title.ToLower()
            //                         select bk;

            //if (getBookListByTitle != null)
            //{
            //    Console.WriteLine("\nCuốn sách bạn đang tìm là:\n");
            //    foreach (Book item in getBookListByTitle)
            //    {
            //        Console.Write(item.Id + "\t");
            //        Console.Write(item.Title + "\t");
            //        Console.Write(item.Author + "\t");
            //        Console.Write(item.Publisher + "\t");
            //        Console.Write(item.Year + "\t");
            //        Console.Write(item.Price + "\t");
            //        Console.WriteLine("\n");
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("Không tìm thấy cuốn sách nào!\n");
            //}

            //// in ra danh sách các cuốn sách in năm 2014
            //var getBookListByYear = from bk in bookList
            //                        where bk.Year == "2014"
            //                        select bk;

            //if (getBookListByYear != null)
            //{
            //    Console.WriteLine("Các cuốn sách in năm 2014 là:\n");
            //    foreach (Book item in getBookListByYear)
            //    {
            //        Console.Write(item.Id + "\t");
            //        Console.Write(item.Title + "\t");
            //        Console.Write(item.Author + "\t");
            //        Console.Write(item.Publisher + "\t");
            //        Console.Write(item.Year + "\t");
            //        Console.Write(item.Price + "\t");
            //        Console.WriteLine("\n");
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("Không tìm thấy cuốn sách nào!\n");
            //}

            //// xóa những cuốn sách của nhà xuất bản "Nhi Dong"
            //Console.WriteLine("Danh sách sau khi xóa là:\n");
            //for (var i = bookList.Count - 1; i >= 0; i--)
            //{
            //    if (bookList[i].Publisher == "Nhi Dong")
            //    {
            //        bookList.RemoveAt(i);
            //    }
            //    else
            //    {
            //        Console.Write(bookList[i].Id + "\t");
            //        Console.Write(bookList[i].Title + "\t");
            //        Console.Write(bookList[i].Author + "\t");
            //        Console.Write(bookList[i].Publisher + "\t");
            //        Console.Write(bookList[i].Year + "\t");
            //        Console.Write(bookList[i].Price + "\t");
            //        Console.WriteLine("\n");
            //    }
            //}

            #endregion

            #region Bài 2

            //Hashtable dayOfWeek = new Hashtable
            //{
            //    { 1, "Monday" },
            //    { 2, "Tuesday" },
            //    { 3, "Wednesday" },
            //    { 4, "Thursday" },
            //    { 5, "Friday" },
            //    { 6, "Saturday" },
            //    { 7, "Sunday" },
            //    {8, "" }
            //};

            //if (dayOfWeek.ContainsValue("Tuesday"))
            //    Console.WriteLine("Tuesday có tồn tại!\n");
            //else
            //    Console.WriteLine("Tuesday không tồn tại!\n");

            //Console.WriteLine("Danh sách cặp Key, Value trong Hashtable:");
            //foreach (DictionaryEntry item in dayOfWeek)
            //{
            //    Console.Write("Key: {0}", item.Key + "\t");
            //    Console.Write("Value: {0}", item.Value + "\n");
            //}

            #endregion

            #region Bài 3

            //var cars = new List<Car>()
            //{
            //    new Car() {Name = "Car 10", Color = "Red"},
            //    new Car() {Name = "Car 11", Color = "Red"},
            //    new Car() {Name = "Car 12", Color = "Black"},
            //    new Car() {Name = "Car 13", Color = "White"},
            //    new Car() {Name = "Car 14", Color = "Black"},
            //    new Car() {Name = "Car 15", Color = "Red"},
            //    new Car() {Name = "Car 16", Color = "Blue"},
            //    new Car() {Name = "Car 17", Color = "Pink"},
            //    new Car() {Name = "Car 18", Color = "Purple"},
            //    new Car() {Name = "Car 19", Color = "Green"}
            //};

            //// in ra danh sách car ban đầu
            //Console.WriteLine("Danh sách ban đầu gồm:\n");
            //foreach(Car car in cars)
            //{
            //    Console.Write(car.Name + "\t\t");
            //    Console.Write(car.Color);
            //    Console.WriteLine("\n");
            //}

            //// xóa các car màu Red và in danh sách
            //Console.WriteLine("Danh sách sau khi xóa gồm:\n");
            //for (var i = cars.Count - 1; i >= 0; i--)
            //{
            //    if (cars[i].Color == "Red")
            //    {
            //        cars.RemoveAt(i);
            //    } else
            //    {
            //        Console.Write(cars[i].Name + "\t\t");
            //        Console.Write(cars[i].Color);
            //        Console.WriteLine("\n");
            //    }
            //}

            #endregion
            #endregion

            #region ArrayList
            int i, count = 0;

            ArrayList books = new ArrayList()
            {
                "Quyển sách thứ nhất",
                "Quyển sách thứ hai",
                "Quyển sách thứ ba",
                "Quyển sách thứ bốn",
                "Quyển sách thứ năm",
                "Quyển sách thứ sáu",
                "Quyển sách thứ bảy",
                "Quyển sách thứ tám",
                "Quyển sách thứ chín",
                "Quyển sách thứ mười",
            };

            // in ra danh sách ban đầu
            Console.WriteLine("Danh sách ban đầu gồm:");
            for(i = 0; i < 10; i++)
            {
                Console.WriteLine("Title: " + books[i]);
            }

            // xóa đi phần tử thứ 2 trong danh sách books
            books.RemoveAt(1);

            //Sửa phần tử đầu tiên trong ArrayList thành "Cafe sáng với Tony".
            books[0] = "Cafe sáng với Tony";

            //Chèn một phần tử có giá trị “C# nhập môn” vào vị trí thứ 4 trong ArrayList.
            books.Insert(3, "C# nhập môn");

            //In ra tổng số phần tử trong ArrayList(Dùng method size()).
            Console.WriteLine("\nTổng số phần tử trong ArrayList là: {0}\n", Size(books));

            //Đếm số phần tử có giá trị “Cafe sáng với Tony” trong danh sách rồi in ra số phần tử này
            for(i = 0; i < Size(books); i++)
            {
                if (books[i].ToString() == "Cafe sáng với Tony")
                {
                    count++;
                }
            }
            Console.WriteLine("Tổng số phần tử trong ArrayList có giá trị “Cafe sáng với Tony” là: {0}\n", count);

            //Xóa tất cả các phần tử trong ArrayList.
            books.Clear();
            #endregion
        }

        static int Size(ArrayList obj)
        {
            return obj.Count;
        }
    }
}
