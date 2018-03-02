using Library.Core.Dto;
using System;
using System.Collections.Generic;

namespace Library.Core.Service
{
    public interface IOrderService
    {
        void Create(Guid userId);
        OrderDto Get(Guid id);
        IEnumerable<OrderDto> Browse(Guid userId);
    }
}
