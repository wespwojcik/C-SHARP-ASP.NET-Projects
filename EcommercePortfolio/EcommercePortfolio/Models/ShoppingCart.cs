using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommercePortfolio.Models
{
    public class ShoppingCart
    {
        private readonly AppDbContext _appDbContext;
        public string ShoppingCartId { get; set; }
        public List <ShoppingCartItem> ShoppingCartItems { get; set; }

        public ShoppingCart(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            //Creates a session and stores the service IHttpContextAccessor's property HttpContext
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            //Get the current db content from the services
            var context = services.GetService<AppDbContext>();
            //Check if the CartId is there, if not we will create a new Guid and convert it to a string
            //and then assign it to string cartId
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            //sets the string to CartId and passes in the the guid that we either retrieved or 
            //a newly created guid.
            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(Item item, int amount)
        {
            //Finds and stores the Item into shoppingcartitems and checks is the
            //ItemId equals the itemid passed in also checks if the 
            //shoppingcartid equals the property of the ShoppingCart.cs
            var shoppingCartItem = _appDbContext.ShoppingCartItems.SingleOrDefault(
                s => s.Item.ItemId == item.ItemId && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                //if null, collect propertys of ShoppingCartItem 
                //that comes in as an argument from this method
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Item = item,
                    Amount = amount
                };
                //Add shoppingcartItem to the appDbContext readonly property

                _appDbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {   //If Candy is in the cart already, increase amount by 1.
                shoppingCartItem.Amount++;
            }

            //saves changes to appDbContext
            _appDbContext.SaveChanges();
        }

        public int RemoveFromCart(Item item)
        {
            //Checks if Item is already in the cart or not and assigns shoppingCartItem 
            // the appDbContext if it'ss
            var shoppingCartItem = _appDbContext.ShoppingCartItems.SingleOrDefault(
                s => s.Item.ItemId == item.ItemId && s.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _appDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            _appDbContext.SaveChanges();

            return localAmount;
        }
        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            //Returns shopping cart items where shoppingcartid matches the id of the dbset 
            // and include all the items 
            return ShoppingCartItems ?? (ShoppingCartItems = _appDbContext.ShoppingCartItems.Where
                (c => c.ShoppingCartId == ShoppingCartId)
                .Include(s => s.Item)
                .ToList());
        }
        public void ClearCart()
        {
            //
            var cartItems = _appDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId);

            _appDbContext.ShoppingCartItems.RemoveRange(cartItems);
            _appDbContext.SaveChanges();

        }
        public decimal GetShoppingCartTotal()
        {
            var total = _appDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Item.Price * c.Amount).Sum();

            return total;
        }
    }
}

