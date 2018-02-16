using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Core.Domain
{
    public class Cart
    {
        private readonly ISet<CartItem> items = new HashSet<CartItem>();
        public IEnumerable<CartItem> Items => items;
        public decimal TotalPrice { get; set; }

        public void DeleteBook(Guid id)
        {
            var book = items.SingleOrDefault(b => b.BookId == id);
            if (book == null)
            {
                throw new Exception("This element does not exist.");
            }
            if (book.Quantity == 1)
            {
                items.Remove(book);

                return;
            }
            book.DecreaseQuantity();
        }
    }
}
