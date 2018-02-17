using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Core.Domain
{
    public class Cart
    {
        private readonly ISet<CartItem> items = new HashSet<CartItem>();
        public IEnumerable<CartItem> Items => items;
        public decimal TotalPrice { get; set; }

        public void AddBook(Book book)
        {
            var item = items.SingleOrDefault(i => i.BookId == book.Id);
            if (item == null)
            {
                item = new CartItem(book);
                items.Add(item);

                return;
            }
            item.IncreaseQuantity();            
        }

        public void ClearCart()
            => items.Clear();

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
