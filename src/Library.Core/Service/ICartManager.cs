using Library.Core.Domain;
using System;

namespace Library.Core.Service
{
    public interface ICartManager
    {
        Cart Get(Guid userId);
        void Set(Guid userId, Cart cart);
        void Delete(Guid userId);
    }
}
