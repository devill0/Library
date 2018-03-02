using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.Core.Domain;

namespace Library.Core.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ISet<Order> orders = new HashSet<Order>();

        public void Add(Order order)
            => orders.Add(order);

        public Order Get(Guid id)
        {
            var order = orders.SingleOrDefault(o => o.Id == id);

            return order;
        }

        public IEnumerable<Order> Browse(Guid userId)
        {
            var order = orders.Where(x => x.UserId == userId);

            return order;
        }
    }
}
