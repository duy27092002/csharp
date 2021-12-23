using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Models.EF;

namespace WindowsFormsApp1.Models.DAO
{
    class CategoryDAO : BaseDAO
    {
        public List<Category> GetCategoryList()
        {
            return db.Categories.ToList();
        }

        public int GetCategoryId(string categoryName)
        {
            return db.Categories.Where(t => t.CategoryName == categoryName).Select(t => t.CategoryId).FirstOrDefault();
        }
    }
}
