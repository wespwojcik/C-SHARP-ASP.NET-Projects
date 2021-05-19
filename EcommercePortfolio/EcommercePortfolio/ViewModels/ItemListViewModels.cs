using EcommercePortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommercePortfolio.ViewModels
{
    public class ItemListViewModels
    {
        public IEnumerable<Item> Items { get; set; }
        public string CurrentCategory { get; set; }
    }
}
