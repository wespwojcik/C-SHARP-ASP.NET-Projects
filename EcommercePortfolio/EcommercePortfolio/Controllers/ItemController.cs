using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommercePortfolio.Models;
using EcommercePortfolio.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EcommercePortfolio.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemRepository _itemRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ItemController(IItemRepository itemRepository, ICategoryRepository categoryRepository)
        {
            _itemRepository = itemRepository;
            _categoryRepository = categoryRepository;
        }
        public IActionResult List(string category)
        {

            IEnumerable<Item> items;
            string currentCategory;

            if (string.IsNullOrEmpty(category))
            {
                items = _itemRepository.GetAllItem.OrderBy(c => c.ItemId);
                currentCategory = "All Item";
            }
            else
            {
                items = _itemRepository.GetAllItem.Where(c => c.category.CategoryName
                == category);

                currentCategory = _categoryRepository.GetAllCategories.FirstOrDefault(c
                    => c.CategoryName == category)?.CategoryName;
            }
            return View(new ItemListViewModels
            { 
                Items = items,
                CurrentCategory = currentCategory

             });
        }
    }
}
