using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Library.Core.Domain;
using Library.Core.Dto;
using Library.Core.Extensions;
using Library.Core.Repository;

namespace Library.Core.Service
{
    public class CartService : ICartService
    {
        private readonly IUserRepository userRepository;
        private readonly IBookRepository bookRepository;
        private readonly ICartManager cartManager;
        private readonly IMapper mapper;

        public CartService(IUserRepository userRepository, 
            IBookRepository bookRepository,
            ICartManager cartManager,
            IMapper mapper)
        {
            this.userRepository = userRepository;
            this.bookRepository = bookRepository;
            this.cartManager = cartManager;
            this.mapper = mapper;
        }

        public CartDto Get(Guid userId)
        {
            var cart = cartManager.Get(userId);

            return cart == null ? null : mapper.Map<CartDto>(cart);
        }

        public void AddBook(Guid userId, Guid bookId)
            => ExecuteOnCart(userId, cart =>
            {
                var book = bookRepository.Get(bookId)
                                         .FailIfNull($"Book with id '{bookId}' was not found.");
                cart.AddBook(book);
            });

        public void DeleteBook(Guid userId, Guid bookId)
            => ExecuteOnCart(userId, cart => cart.DeleteBook(bookId));

        public void Clear(Guid userId)
            => ExecuteOnCart(userId, cart => cart.ClearCart());

        public void Create(Guid userId)
        {
            cartManager.Get(userId).FailIfExists($"Cart already exists for user with id: '{userId}'.");
            cartManager.Set(userId, new Cart());
        }

        public void Delete(Guid userId)
        {
            GetCartOrFail(userId);
            cartManager.Delete(userId);
        }

        private void ExecuteOnCart(Guid userId, Action<Cart> action)
        {
            var cart = GetCartOrFail(userId);
            action(cart);
            cartManager.Set(userId, cart);
        }

        private Cart GetCartOrFail(Guid userId)
        => cartManager.Get(userId).FailIfNull($"Cart was not found for user with id: '{userId}'.");
    }
}
