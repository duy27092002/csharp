using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagermentProduct_Winform
{
    public class Product
    {
        private int id;
        private string pName;
        private float price;
        private float discounting;
        public int Id { get; set; }
        public string PName { get; set; }
        public float Price { get; set; }
        public float Discounting { get; set; }
    }
}
