using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommercePortfolio.Models
{
    public interface IItemRepository 
    {
        //Defines IEnumerables for gathering and returning data to the database. 
        IEnumerable<Item> GetAllItem { get; }
        IEnumerable<Item> GetItemOnSale { get; }
        Item GetItemById(int ItemId);
    }
}
