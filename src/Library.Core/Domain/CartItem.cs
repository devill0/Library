using System;

namespace Library.Core.Domain
{
    public class CartItem
    {
        public Guid BookId { get; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal TotalPrice => Quantity * UnitPrice;

        public CartItem(Book book)
        {
            BookId = book.Id;
            Title = book.Title;
            Author = book.Author;
            UnitPrice = book.Price;
            Quantity = 1;
        }

        public void IncreaseQuantity()
        {
            Quantity++;
        }

        public void DecreaseQuantity()
        {
            if (Quantity <= 1)
            {
                throw new Exception("Quantity can not be lower than 1.");
            }
            Quantity--; 
        }
    }
}
