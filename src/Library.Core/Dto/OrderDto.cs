using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Core.Dto
{
    public class OrderDto
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public IEnumerable<OrderItemDto> Items { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
