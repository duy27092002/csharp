using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Models.EF;

namespace WindowsFormsApp1.Models.DAO
{
    class ProductDAO : BaseDAO
    {
        public List<Product> GetProducts(int categoryId, float minPrice, float maxPrice)
        {
            return db.Products.Where(
                t => t.CategoryId == categoryId &&
                t.Price >= minPrice &&
                t.Price <= maxPrice
                ).ToList();
        }
    }
}
