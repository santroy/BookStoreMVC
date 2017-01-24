using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookstoreMVC.Models
{
    public class OrderItem
    {
        public int OrderItemID { get; set; }
        public int OrderID { get; set; }
        public int BookId {get; set;}
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public virtual Book Book { get; set; }
        public virtual Order Order { get; set; }
    }
}