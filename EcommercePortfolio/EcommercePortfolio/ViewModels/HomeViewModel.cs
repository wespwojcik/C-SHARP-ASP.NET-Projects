﻿using EcommercePortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommercePortfolio.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Item> ItemOnSale { get; set; }
    }
}
