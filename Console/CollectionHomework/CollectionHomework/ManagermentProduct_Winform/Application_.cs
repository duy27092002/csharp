using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagermentProduct_Winform
{
    public class Application_
    {
        List<Product> products = new List<Product>();

        // kiểm tra đầu vào khi thêm mới sản phẩm
        private static bool CheckInput(string id, string price, string discounting)
        {
            Regex checkNumber = new Regex(@"^[+]?\d+$");

            if (!checkNumber.IsMatch(id) || !checkNumber.IsMatch(price) || !checkNumber.IsMatch(discounting))
            {
                MessageBox.Show("Id, giá và chiết khấu phải là một con số dương", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                if (float.Parse(discounting) < 5 || float.Parse(discounting) > 10)
                {
                    MessageBox.Show("Chiết khấu phải là nằm từ 5 đến 10", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }

        public bool Add(string name, string id, string price, string discounting)
        {
            int j;
            bool flag = true;
            Product prod = new Product();

            // thêm vào List<Product>
            if (name.Length == 0 || id.Length == 0 || price.Length == 0 || discounting.Length == 0)
            {
                MessageBox.Show("Không được để trống dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            } 
            else
            {
                if (CheckInput(id, price, discounting))
                {
                    prod.Id = int.Parse(id);
                    prod.PName = name;
                    prod.Price = float.Parse(price);
                    prod.Discounting = float.Parse(discounting);

                    // kiểm tra id là duy nhất
                    // nếu danh sách chưa có sp thì thêm thẳng vào
                    if (products.Count() == 0 || products == null)
                    {
                        products.Add(prod);
                    }
                    else // nếu danh sách đã có sẵn sp thì bắt đầu kiểm tra id
                    {
                        for (j = 0; j < products.Count(); j++)
                        {
                            if (products[j].Id == prod.Id)
                            {
                                flag = false;
                                break;
                            }
                        }

                        if (flag)
                        {
                            products.Add(prod);
                        }
                        else
                        {
                            MessageBox.Show("Id bị trùng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                } 
                else
                {
                    return false;
                }
            }

            return true;
        }

        public Product GetProductById(int id)
        {
            var getProductInfo = from pro in products
                                 where pro.Id == id
                                 select pro;

            return getProductInfo.FirstOrDefault();
        }

        public bool Update(string id, string name, string price, string discounting)
        {
            if (name.Length == 0 || price.Length == 0)
            {
                MessageBox.Show("Không được để trống dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                if (CheckInput(id, price, discounting))
                {
                    var getProductInfo = GetProductById(int.Parse(id));

                    getProductInfo.PName = name;
                    getProductInfo.Price = float.Parse(price);
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        public bool Delete(string id)
        {
            var getProduct = GetProductById(int.Parse(id));

            if (getProduct != null)
            {
                products.Remove(getProduct);
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi trong quá trình xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        public List<Product> GetList()
        {
            return products;
        }

        public int CountByMaxPrice()
        {
            var sortDescByPrice = products.OrderByDescending(t => t.Price).Select(t => t).FirstOrDefault();

            var getProducts = from pro in products
                              where pro.Price == sortDescByPrice.Price
                              select pro;

            return getProducts.Count();
        }

        // kiểm tra đơn giá tối thiểu và tối đa khi thực hiện tìm kiếm sp theo đơn giá
        public bool CheckMinMaxPrice(string minPrice, string maxPrice)
        {
            Regex checkNumber = new Regex(@"^[+]?\d+$");

            if (minPrice.Length == 0 || maxPrice.Length == 0)
            {
                MessageBox.Show("Không được để trống dữ liệu đơn giá!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                if (checkNumber.IsMatch(minPrice) && checkNumber.IsMatch(maxPrice))
                {
                    if (float.Parse(minPrice) >= float.Parse(maxPrice))
                    {
                        MessageBox.Show("Đơn giá nhỏ nhất và lớn nhất có vấn đề", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Đơn giá phải là một con số lớn hơn hoặc bằng 0", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }

        public List<Product> GetProductListByPrice(string minPrice, string maxPrice)
        {
            var getByPrice = (from pro in products
                             where pro.Price >= float.Parse(minPrice) && pro.Price <= float.Parse(maxPrice)
                             select pro).ToList();

            return getByPrice;
        }
    }
}
