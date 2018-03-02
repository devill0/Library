using Library.Core.Domain;
using System;
using System.Collections.Generic;

namespace Library.Core.Repository
{
    public interface IOrderRepository
    {
        void Add(Order order);
        Order Get(Guid id);
        IEnumerable<Order> Browse(Guid userId);
    }
}
