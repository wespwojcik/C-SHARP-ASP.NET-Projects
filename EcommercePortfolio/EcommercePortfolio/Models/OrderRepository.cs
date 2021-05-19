using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommercePortfolio.Models
{
    public class OrderRepository : IOrderRepository
    {

        private readonly AppDbContext _appDbContext;
        private readonly ShoppingCart _shoppingCart;

        public OrderRepository(AppDbContext appDbContext, ShoppingCart shoppingCart)
        {
            _appDbContext = appDbContext;
            _shoppingCart = shoppingCart;
        }
        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;//Collects the current date and stores it in the OrderPlaced property of the order object
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();//Collects the total of the current shopping cart
            _appDbContext.Orders.Add(order);//Adds the collected contents of order to the Orders db set
            _appDbContext.SaveChanges();//Saves changes to the database

            var shoppingCartItems = _shoppingCart.GetShoppingCartItems();//Creates a variable and makes it equal to all current shopping cart items 

            foreach (var shoppingCartItem in shoppingCartItems)//Loops through your shopping cart items
            {
                var orderDetail = new OrderDetail //Creates a an object of OrderDetail
                {
                    Amount = shoppingCartItem.Amount,//collects the amount of the shopping cart
                    Price = shoppingCartItem.Item.Price,//price of the Item
                    ItemId = shoppingCartItem.Item.ItemId,//Item id
                    OrderId = order.OrderId//and the Orderid

                };

                _appDbContext.OrderDetails.Add(orderDetail);//Adds the contents of the order detail object to the OrderDetails Dbset
            }
            _appDbContext.SaveChanges();//Saves changes to the database.
        }
    }
}
