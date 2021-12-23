using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ManagermentProduct_ConsoleApp
{
    public class Application
    {
        List<Product> products = new List<Product>();

        // kiểm tra đầu vào khi thêm mới sản phẩm
        private static bool CheckInput(string id, string price, string discounting)
        {
            Regex checkNumber = new Regex(@"^[+]?\d+$");

            if (!checkNumber.IsMatch(id) || !checkNumber.IsMatch(price) || !checkNumber.IsMatch(discounting))
            {
                Console.WriteLine("\nId, giá và chiết khấu phải là một con số dương. Vui lòng nhập lại!");
                return false;
            }
            else if (checkNumber.IsMatch(discounting))
            {
                if (float.Parse(discounting) < 5 || float.Parse(discounting) > 10)
                {
                    Console.WriteLine("\nChiết khấu phải là nằm từ 5 đến 10. Vui lòng nhập lại!");
                    return false;
                }
            }

            return true;
        }

        // kiểm tra đơn giá tối thiểu và tối đa khi thực hiện tìm kiếm sp theo đơn giá
        private static bool CheckPrice(string minPrice, string maxPrice)
        {
            Regex checkNumber = new Regex(@"^[+]?\d+$");

            if (checkNumber.IsMatch(minPrice) && checkNumber.IsMatch(maxPrice))
            {
                if (float.Parse(minPrice) >= float.Parse(maxPrice))
                {
                    Console.WriteLine("\nĐơn giá nhỏ nhất và lớn nhất có vấn đề! Chương trình kết thúc.");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("\nĐơn giá phải là một con số lớn hơn hoặc bằng 0! Chương trình kết thúc.");
                return false;
            }

            return true;
        }

        // kiểm tra id khi thực hiện sửa hoặc xóa và số lượng sp nhập từ bàn phím
        private static bool CheckIdOrSizeIsNumber(string param)
        {
            Regex checkNumber = new Regex(@"^[+]?\d+$");

            if (!checkNumber.IsMatch(param))
            {
                Console.WriteLine("\nHãy một con số lớn hơn 0!\n");
                return false;
            } 
            else
            {
                if (int.Parse(param) == 0)
                {
                    Console.WriteLine("\nHãy một con số lớn hơn 0!\n");
                    return false;
                } 
                else
                {
                    return true;
                }
            }
        }

        // set id khi chuẩn bị sửa or xóa sp
        private static int SetIdToEditOrDelete()
        {
            Console.Write("\nNhập Id sản phẩm: Id = ");
            int id = int.Parse(Console.ReadLine());

            return id;
        }

        // menu các thao tác của chương trình
        public void Menu()
        {
            Console.WriteLine("\nĐây là menu cho bạn thao tác: Nếu muốn");
            Console.WriteLine("\nThêm sản phẩm thì nhập 'Yes'");
            Console.WriteLine("\nSửa sản phẩm thì nhập 'Edit'");
            Console.WriteLine("\nXóa sản phẩm thì nhập 'Delete'");
            Console.WriteLine("\nHiển thị danh sách thì và kết thúc chương trình nhập 'Display':");
            Console.WriteLine("\nLấy danh sách theo khoảng giá nhập 'By price':");
            Console.WriteLine("\nTổng số sản phẩm có đơn giá cao nhất 'By max price':");

            Console.Write("\nVậy bạn muốn: ");
            string getAnswer = Console.ReadLine().ToLower();

            switch (getAnswer)
            {
                case "yes":
                    {
                        Add(true);
                        break;
                    }
                case "display":
                    {
                        if (products.Count() > 0)
                        {
                            Console.WriteLine("\nDanh sách sản phẩm gồm:\n");

                            Display(products);
                        }
                        else
                        {
                            Console.WriteLine("\nDanh sách trống!\n");
                        }
                        break;
                    }
                case "edit":
                    {
                        UpdateNameAndPriceProduct();
                        break;
                    }
                case "delete":
                    {
                        DeleteProductById();
                        break;
                    }
                case "by price":
                    {
                        GetProductByPrice();
                        break;
                    }
                case "by max price":
                    {
                        GetCountByMaxPrice();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("\nLựa chọn không phù hợp! Kết thúc chương trình.");
                        break;
                    }
            }
        }

        // thực hiện thêm mới sp
        public void Add(bool isAdd)
        {
            if (isAdd)
            {
                int i = 0, j;
                string id, name, price, discounting, size;

                Console.Write("\nBạn muốn nhập bao nhiêu sản phẩm: ");
                size = Console.ReadLine();

                if (CheckIdOrSizeIsNumber(size))
                {
                    Console.WriteLine("\nHãy nhập thông tin cho sản phẩm:");

                    while (i < int.Parse(size))
                    {
                        Product prod = new Product();

                        bool flag = true;

                        Console.WriteLine("\nSản phẩm thứ {0}:", i + 1);

                        #region Nhập liệu
                        Console.Write("Id: ");
                        id = Console.ReadLine();

                        Console.Write("Tên: ");
                        name = Console.ReadLine();

                        Console.Write("Đơn giá: ");
                        price = Console.ReadLine();

                        Console.Write("Chiết khấu (từ 5% đến 10%): ");
                        discounting = Console.ReadLine();
                        #endregion

                        if (name.Length == 0)
                        {
                            Console.WriteLine("\nKhông được để trống dữ liệu!");
                            break;
                        }
                        else
                        {
                            // thêm vào List<Product>
                            if (CheckInput(id, price, discounting))
                            {
                                prod.Id = int.Parse(id);
                                prod.PName = name;
                                prod.Price = float.Parse(price);
                                prod.Discounting = float.Parse(discounting);

                                products.Add(prod);
                            }
                            else
                            {
                                break;
                            }
                        }

                        #region Kiểm tra Id là duy nhất
                        if (i != 0)
                        {
                            for (j = 0; j < i; j++)
                            {
                                if (products[j].Id == products[i].Id)
                                {
                                    Console.WriteLine("\nId bị trùng. Vui khởi động lại chương trình!");
                                    flag = false;
                                    break;
                                }
                            }
                        }

                        if (!flag)
                        {
                            products.Clear();
                            break;
                        }
                        #endregion

                        i++;
                    }

                    // hỏi xem người dùng có muốn thực hiện các thao tác trong menu kia k?
                    Menu();
                } else
                {
                    return;
                }
            }
        }

        // lấy danh sách sp theo đơn giá
        public void GetProductByPrice()
        {
            string minPrice, maxPrice;

            Console.Write("\nNhập đơn giá nhỏ nhất: ");
            minPrice = Console.ReadLine();

            Console.Write("\nNhập đơn giá cao nhất: ");
            maxPrice = Console.ReadLine();

            if (CheckPrice(minPrice, maxPrice))
            {
                var getProducts = from pro in products
                                  where pro.Price >= float.Parse(minPrice) && pro.Price <= float.Parse(maxPrice)
                                  select pro;

                if (getProducts.Count() > 0)
                {
                    Console.WriteLine("\nDanh sách sản phẩm tìm theo đơn giá từ {0} đến {1} gồm:\n", minPrice, maxPrice);

                    Display(getProducts.ToList());
                }
                else
                {
                    Console.WriteLine("\nKhông tìm thấy kết quả nào!\n");
                }
            }

            Menu();
        }

        // tìm tổng số sp có đơn giá cao nhất
        public void GetCountByMaxPrice()
        {
            var sortDescByPrice = products.OrderByDescending(t => t.Price).Select(t => t).FirstOrDefault();

            var getProducts = from pro in products
                              where pro.Price == sortDescByPrice.Price
                              select pro;

            Console.WriteLine("\nCó {0} sản phẩm có giá cao nhất (giá = {1})", getProducts.Count(), sortDescByPrice.Price);

            Menu();
        }

        // cập nhật tên và đơn giá sau khi sửa sp
        public void UpdateNameAndPriceProduct()
        {
            string name, price, id;

            id = SetIdToEditOrDelete().ToString();

            if (CheckIdOrSizeIsNumber(id))
            {
                var getProduct = from pro in products
                                 where pro.Id == int.Parse(id)
                                 select pro;

                if (getProduct.Count() > 0)
                {
                    Console.Write("\nSửa tên sản phẩm thành: ");
                    name = Console.ReadLine();

                    Console.Write("\nSửa đơn giá thành: ");
                    price = Console.ReadLine();

                    if (name.Length == 0)
                    {
                        Console.WriteLine("\nKhông được để trống dữ liệu!");
                    }
                    else
                    {
                        foreach (Product item in getProduct)
                        {
                            if (CheckInput(item.Id.ToString(), price, item.Discounting.ToString()))
                            {
                                item.PName = name;
                                item.Price = float.Parse(price);
                            }
                            else
                            {
                                return;
                            }
                        }

                        if (products.Count > 0)
                        {
                            Console.WriteLine("\nDanh sách sản phẩm sau khi sửa như sau:\n");
                            Display(products);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("\nKhông tìm thấy sản phẩm nào có id như vậy!");
                }
            }

            Menu();
        }

        // hiển thị danh sách sp
        public void Display(List<Product> products)
        {
            foreach (Product item in products)
            {
                Console.Write(item.Id + "\t");
                Console.Write(item.PName + "\t");
                Console.Write(item.Price + "\t");
                Console.Write(item.Discounting + "\t");
                Console.WriteLine("\n");
            }
        }

        // xóa 1 sp
        public void DeleteProductById()
        {
            string id;

            id = SetIdToEditOrDelete().ToString();

            if (CheckIdOrSizeIsNumber(id))
            {
                var getProToRemove = products.Single(t => t.Id == int.Parse(id));

                products.Remove(getProToRemove);

                if (products.Count > 0)
                {
                    Console.WriteLine("\nDanh sách sản phẩm sau khi xóa gồm:");

                    Display(products);
                }
                else
                {
                    Console.WriteLine("\nDanh sách sản phẩm đang trống!\n");
                }
            }

            Menu();
        }
    }
}
