using AutoMapper;
using Library.Core.Service;
using Library.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Library.Web.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IOrderService orderService;
        private readonly IMapper mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            this.orderService = orderService;
            this.mapper = mapper;
        }

        [HttpGet("orders")]
        public IActionResult Index()
        {
            var order = orderService.Browse(CurrrentUserId);
            var viewModel = mapper.Map<IEnumerable<OrderViewModel>>(order);

            return View(order);
        }

        [HttpPost("orders")]
        public IActionResult Create()
        {
            try
            {
                orderService.Create(CurrrentUserId);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}