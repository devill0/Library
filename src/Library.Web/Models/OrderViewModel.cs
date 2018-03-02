using System;
using System.Collections.Generic;

namespace Library.Web.Models
{
    public class OrderViewModel
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public IEnumerable<OrderItemViewModel> Items { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
