using System;
using AutoMapper;
using Library.Core.Service;
using Library.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Web.Controllers
{
    [Route("cart")]
    public class CartController : BaseController
    {
        private readonly ICartService cartService;
        private readonly IMapper mapper;

        public CartController(CartService cartService, IMapper mapper)
        {
            this.cartService = cartService;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var cart = cartService.Get(CurrrentUserId);
            if (cart == null)
            {
                cartService.Create(CurrrentUserId);
                cart = cartService.Get(CurrrentUserId);
            }
            var viewModel = mapper.Map<CartViewModel>(cart);

            return View(viewModel);
        }        

        [HttpPost("items/{bookId}")]
        public IActionResult AddBook(Guid bookId)
        {
            cartService.AddBook(CurrrentUserId, bookId);

            return Ok();
        }

        [HttpDelete("items/{bookId}")]
        public IActionResult DeleteBook(Guid bookId)
        {
            cartService.DeleteBook(CurrrentUserId, bookId);

            return Ok();
        }
    }
}