using System.Collections.Generic;

namespace Library.Core.Dto
{
    public class CartDto
    {
        public IEnumerable<CartDto> Items { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
