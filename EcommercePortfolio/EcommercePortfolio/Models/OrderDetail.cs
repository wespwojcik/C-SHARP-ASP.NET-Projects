using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommercePortfolio.Models
{
    public class OrderDetail
    {
        //Id of the order detail
        public int OrderDetailId { get; set; }
        //Id of the actual order
        public int OrderId { get; set; }
        //id of the actual item 
        public int ItemId { get; set; }
        //The item
        public Item Item { get; set; }
        //amount of items being ordered
        public int Amount { get; set; }
        //Takes into the account the price of the order
        public decimal Price { get; set; }
        //Creates the relationship between the order and order details
        public Order Order { get; set; }
    }
}
