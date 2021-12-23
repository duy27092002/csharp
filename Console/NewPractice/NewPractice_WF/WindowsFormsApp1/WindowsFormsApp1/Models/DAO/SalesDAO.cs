using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Models.EF;

namespace WindowsFormsApp1.Models.DAO
{
    class SalesDAO : BaseDAO
    {
        public Sale GetItem(string itemNo)
        {
            return db.Sales.Where(t => t.ItemNo == itemNo).FirstOrDefault();
        }

        public bool AddNewItem(Sale data)
        {
            try
            {
                db.Sales.Add(data);
                db.SaveChanges();
            } catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool SaveItem(Sale data)
        {
            Sale getItem = GetItem(data.ItemNo);

            if (getItem != null)
            {
                try
                {
                    getItem.ItemName = data.ItemName;
                    getItem.Price = data.Price;
                    getItem.Quantity = data.Quantity;
                    getItem.DateOfSales = data.DateOfSales;
                    getItem.ModeOfPayment = data.ModeOfPayment;

                    db.SaveChanges();
                } catch (Exception ex)
                {
                    return false;
                }
            } else
            {
                return false;
            }
            return true;
        }
    }
}
