using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Core.Domain
{
    public class OrderItem
    {
        public Guid BookId { get; }
        public string Title { get; }
        public string Author { get; }
        public int Quantity { get; }
        public decimal UnitPrice { get; }
        public decimal TotalPrice { get; }

        public OrderItem(CartItem item)
        {
            BookId = item.BookId;
            Title = item.Title;
            Author = item.Author;
            Quantity = item.Quantity;
            UnitPrice = item.UnitPrice;
            TotalPrice = item.TotalPrice;
        }
    }
}
