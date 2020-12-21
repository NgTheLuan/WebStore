using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebStore.Models
{
    public class CART
    {
        public int ID_Product { get; set; }
        public string ProductName { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
        public float Total { get { return Quantity * Price; } }
    }
}