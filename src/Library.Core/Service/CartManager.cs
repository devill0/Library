using System;
using Library.Core.Domain;
using Microsoft.Extensions.Caching.Memory;


namespace Library.Core.Service
{
    public class CartManager : ICartManager
    {
        private readonly IMemoryCache memoryCache;

        public CartManager(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }

        public void Delete(Guid userId)
            => memoryCache.Remove(userId);

        public Cart Get(Guid userId)
            => memoryCache.Get<Cart>(userId);

        public void Set(Guid userId, Cart cart)
            => memoryCache.Set(userId, cart, TimeSpan.FromDays(7));
    }
}
