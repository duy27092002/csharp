using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebSales.Models.EF;

namespace WebSales.Models.DAO
{
    public class CustomerDAO : BaseDAO, ICustomerDAO
    {
        public async Task<bool> Add(Customer entity)
        {
            try
            {
                _context.Customers.Add(entity);

                await _context.SaveChangesAsync();
            } catch(Exception ex)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                Customer entity = await GetSingleByID(id);

                _context.Customers.Remove(entity);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public async Task<List<Customer>> GetAll()
        {
            List<Customer> customers = await _context.Customers.ToListAsync();

            return customers;
        }

        public async Task<List<Customer>> GetByKeyword(string keyword)
        {
            List<Customer> customers = await _context.Customers
                .Where(t => t.Fullname.Contains(keyword))
                .ToListAsync();

            return customers;
        }

        public async Task<IPagedList<Customer>> GetByPaged(int page, int pageSize, string keyword)
        {
            List<Customer> customers = await GetByKeyword(keyword);

            IPagedList<Customer> pagedListCustomers = customers.ToPagedList(page, pageSize);

            return pagedListCustomers;
        }

        public async Task<Customer> GetSingleByID(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task<bool> Update(Customer entity)
        {
            try
            {
                Customer cEntity = await GetSingleByID(entity.ID);

                if (cEntity != null)
                {
                    cEntity.Fullname = entity.Fullname;
                    cEntity.Password = entity.Password;
                    cEntity.Email = entity.Email;
                    cEntity.Photo = entity.Photo;
                    cEntity.Activated = entity.Activated;

                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }
    }
}