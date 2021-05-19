using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommercePortfolio.Models
{
    public class ItemRepository : IItemRepository  
    {
        private readonly AppDbContext _appDbContext;

        public ItemRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

       //Implements the Item Interface
        public IEnumerable<Item> GetAllItem
        {
            get
            {
                //Returns the items and the category for each item
                return _appDbContext.Items.Include(c => c.category);
            }
        }


        public IEnumerable<Item> GetItemOnSale
        {
            get
            {
                //Returns the items and the category for each item when the item is on sale 
                return _appDbContext.Items.Include(c => c.category).Where(p => p.IsOnSale);
            }
        }

        public Item GetItemById(int ItemId)
        {

            return GetAllItem.FirstOrDefault(c => c.ItemId == ItemId);
        }
    }
}
