using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommercePortfolio.Models;
using EcommercePortfolio.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EcommercePortfolio.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IItemRepository _IitemRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(IItemRepository itemRepository, ShoppingCart shoppingCart)
        {
            _IitemRepository = itemRepository;
            _shoppingCart = shoppingCart;
        }

        public IActionResult Index()
        {

            _shoppingCart.ShoppingCartItems = _shoppingCart.GetShoppingCartItems();
            //creating a view model representing and returning the data from out shopping cart repository
            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };    
            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(int itemId)
        {
            //Assign a variable with all the Items using the Item repository
            var selectedItem = _IitemRepository.GetAllItem.FirstOrDefault(c => c.ItemId == itemId);

            if(selectedItem != null)
            {
                _shoppingCart.AddToCart(selectedItem, 1);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int ItemId)
        {
            var selectedItem = _IitemRepository.GetAllItem.FirstOrDefault(c => c.ItemId == ItemId);

            if (selectedItem != null)
            {
                _shoppingCart.RemoveFromCart(selectedItem);
            }

            return RedirectToAction("Index");
        }
    }
}
