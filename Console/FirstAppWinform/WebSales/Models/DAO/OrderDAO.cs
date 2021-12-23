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
    public class OrderDAO : BaseDAO, IOrderDAO
    {
        public async Task<bool> Add(Order entity)
        {
            try
            {
                _context.Orders.Add(entity);

                await _context.SaveChangesAsync();
            } catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                Order entity = await GetSingleByID(id);

                _context.Orders.Remove(entity);

                await _context.SaveChangesAsync();
            } catch(Exception ex)
            {
                return false;
            }

            return true;
        }

        public async Task<List<Order>> GetAll()
        {
            List<Order> orders = await _context.Orders.ToListAsync();

            return orders;
        }

        public async Task<List<Order>> GetByKeyword(string keyword)
        {
            List<Order> orders = await _context.Orders
                .Where(t => t.Address.Contains(keyword))
                .ToListAsync();

            return orders;
        }

        public async Task<IPagedList<Order>> GetByPaged(int page, int pageSize, string keyword)
        {
            List<Order> orders = await GetByKeyword(keyword);

            IPagedList<Order> pagedListOrders = orders.ToPagedList(page, pageSize);

            return pagedListOrders;
        }

        public async Task<Order> GetSingleByID(int id)
        {
            Order order = await _context.Orders.FindAsync(id);

            return order;
        }

        public async Task<bool> Update(Order entity)
        {
            try
            {
                Order cEntity = await GetSingleByID(entity.ID);

                if (cEntity != null)
                {
                    cEntity.CustomerId = entity.CustomerId;
                    cEntity.Address = entity.Address;
                    cEntity.Amount = entity.Amount;
                    cEntity.Description = entity.Description;

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