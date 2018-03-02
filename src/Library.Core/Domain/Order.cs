using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Core.Domain
{
    public class Order
    {
        public Guid UserId { get; }
        public Guid Id { get; }
        public IEnumerable<OrderItem> Items { get; }
        public DateTime CreatedAt { get; }
        public decimal TotalPrice { get; }

        public Order(Cart cart, User user)
        {
            if (cart.Items == null)
            {
                throw new Exception("You can not create an order for empty cart!");
            }
            UserId = user.Id;
            Id = Guid.NewGuid();
            Items = cart.Items.Select(x => new OrderItem(x));
            TotalPrice = cart.TotalPrice;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
