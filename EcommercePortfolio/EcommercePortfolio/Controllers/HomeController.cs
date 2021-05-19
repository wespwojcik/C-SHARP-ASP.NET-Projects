using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EcommercePortfolio.Models;
using EcommercePortfolio.ViewModels;

namespace EcommercePortfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly IItemRepository _iitemRepository;

        public HomeController(IItemRepository itemRepository)
        {
            _iitemRepository = itemRepository;
        }
        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                ItemOnSale = _iitemRepository.GetItemOnSale
            };
            return View(homeViewModel);
        }
    }
}
