using Library.Core.Dto;
using System;

namespace Library.Web.Models
{
    public class OrderItemViewModel
    {
        public Guid BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
