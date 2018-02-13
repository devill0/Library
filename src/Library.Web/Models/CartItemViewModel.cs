using System;

namespace Library.Web.Models
{
    public class CartItemViewModel
    {
        public Guid BookId { get; set; }
        public string Title { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get { return Quantity * UnitPrice; } }
    }
}
