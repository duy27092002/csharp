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
    public class ProductDAO : BaseDAO, IProductDAO
    {
        public async Task<bool> Add(Product entity)
        {
            try
            {
                _context.Products.Add(entity);

                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                Product entity = await GetSingleByID(id);

                _context.Products.Remove(entity);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public async Task<List<Product>> GetAll()
        {
            List<Product> products = await _context.Products.ToListAsync();

            return products;
        }

        public async Task<List<Product>> GetByKeyword(string keyword)
        {
            List<Product> products = await _context.Products
                .Where(t => t.Name.Contains(keyword))
                .ToListAsync();

            return products;
        }

        public async Task<IPagedList<Product>> GetByPaged(int page, int pageSize, string keyword)
        {
            List<Product> products = await GetByKeyword(keyword);

            IPagedList<Product> pagedListProducts = products.ToPagedList(page, pageSize);

            return pagedListProducts;
        }

        public async Task<Product> GetSingleByID(int id)
        {
            Product product = await _context.Products.FindAsync(id);

            return product;
        }

        public async Task<bool> Update(Product entity)
        {
            try
            {
                Product cEntity = await GetSingleByID(entity.ID);

                if (cEntity != null)
                {
                    cEntity.Name = entity.Name;
                    cEntity.UnitPrice = entity.UnitPrice;
                    cEntity.Image = entity.Image;
                    cEntity.ProductDate = entity.ProductDate;
                    cEntity.CategoryId = entity.CategoryId;
                    cEntity.Description = entity.Description;
                    cEntity.Available = entity.Available;

                    await _context.SaveChangesAsync();
                }
            } catch (Exception ex)
            {
                return false;
            }

            return true;
        }
    }
}