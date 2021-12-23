using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Models.EF;

namespace WindowsFormsApp1.Models.DAO
{
    class CustomerDAO : BaseDAO
    {

        public int GetPageCount()
        {
            int getCountOfRecord = db.Customers.Count();
            int getPageCount = (getCountOfRecord % 2) == 0 ? (getCountOfRecord / 2) : (getCountOfRecord / 2) + 1;
            return getPageCount;
        }

        public List<Customer> GetCusByPage(int pageNubmer)
        {
            // trả về 2 khách hàng mỗi trang
            return db.Customers.OrderByDescending(t => t.CustomerId).Skip((pageNubmer - 1) * 2).Take(2).ToList();
        }

        public bool AddNewCustomer(Customer data)
        {
            try
            {
                db.Customers.Add(data);
                db.SaveChanges();
            } catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public Customer GetCustomerById(string customerId)
        {
            return db.Customers.Find(customerId);
        }

        public bool UpdateCustomer(Customer data)
        {
            Customer getCustomer = GetCustomerById(data.CustomerId);

            if (getCustomer != null)
            {
                try
                {
                    getCustomer.CustomerId = data.CustomerId;
                    getCustomer.FirstName = data.FirstName;
                    getCustomer.LastName = data.LastName;
                    getCustomer.Phone = data.Phone;
                    getCustomer.Email = data.Email;
                    getCustomer.Address = data.Address;

                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return false;
        }
    }
}
