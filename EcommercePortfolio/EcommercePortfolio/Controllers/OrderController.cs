using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommercePortfolio.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommercePortfolio.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ShoppingCart _shoppingcart;

        public OrderController(IOrderRepository orderRepository, ShoppingCart shoppingCart)
        {
            _orderRepository = orderRepository;
            _shoppingcart = shoppingCart;
        }
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            _shoppingcart.ShoppingCartItems = _shoppingcart.GetShoppingCartItems();

            if (_shoppingcart.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is empty");
            }

            if (ModelState.IsValid)
            {
                _orderRepository.CreateOrder(order);
                _shoppingcart.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }
            return View(order);
        }

        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thank you for your order. Enjoy your purchase!";

            return View();
        }
    }
}
