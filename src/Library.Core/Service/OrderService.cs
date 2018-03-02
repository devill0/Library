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
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;
        private readonly IUserRepository userRepository;
        private readonly ICartManager cartManager;
        private readonly IMapper mapper;

        public OrderService(IOrderRepository orderRepository,
            IUserRepository userRepository,
            IMapper mapper)
        {
            this.orderRepository = orderRepository;
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public IEnumerable<OrderDto> Browse(Guid userId)
            => orderRepository.Browse(userId)
                              .Select(x => mapper.Map<OrderDto>(x));

        public void Create(Guid userId)
        {
            var user = userRepository.Get(userId)
                                     .FailIfNull($"User with id: {userId} does not exist.");
            var cart = cartManager.Get(userId)
                .FailIfNull($"Cart for user with id: {userId} was not found.");
            var order = new Order(cart, user);
            orderRepository.Add(order);
            cart.ClearCart();
            cartManager.Set(userId, cart);
        }

        public OrderDto Get(Guid id)
        {
            var order = orderRepository.Get(id);

            return order == null ? null : mapper.Map<OrderDto>(order);
        }
    }
}
