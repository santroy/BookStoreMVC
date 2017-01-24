using BookstoreMVC.DAL;
using BookstoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookstoreMVC.Infrastructure
{
    public class ShoppingCartManager
    {
        private ShopContext db;
        private ISessionManager session;
        public const string CartSessionKey = "CartData";
        public ShoppingCartManager(ISessionManager session, ShopContext db)
        {

            this.session = session;
            this.db = db;

        }

        public void AddToCart(int bookid)
        {

            var cart = this.GetCart();
            var cartItem = cart.Find(c => c.Book.BookID == bookid);

            if (cartItem != null) { cartItem.Quantity++; } else {

                var bookToAdd = db.Books.Where(b => b.BookID == bookid).SingleOrDefault();

                if (bookToAdd != null) {

                    var newCartItem = new CartItem()
                    {

                        Book = bookToAdd,
                        Quantity = 1,
                        TotalPrice = bookToAdd.Price

                    };

                    cart.Add(newCartItem);
                }
            }
            session.Set(CartSessionKey, cart);

        }

        public List<CartItem> GetCart()
        {

            List<CartItem> cart;

            if (session.Get<List<CartItem>>(CartSessionKey) == null) {
                cart = new List<CartItem>();
            } else
            {
                cart = session.Get<List<CartItem>>(CartSessionKey) as List<CartItem>;
            }
            return cart;
        }

        public int RemoveFromCart(int bookid)
        {
            var cart = this.GetCart();
            var cartItem = cart.Find(c => c.Book.BookID == bookid);

            if (cartItem.Quantity > 1)
            {

                cartItem.Quantity--;
                return cartItem.Quantity;

            } else
            {

                cart.Remove(cartItem);

            }

            return 0;
        }

        public decimal GetCartTotalPrice()
        {
            var cart = this.GetCart();
            return cart.Sum(c => (c.Quantity * c.Book.Price));
        }

        public int GetCartItemCount()
        {
            var cart = this.GetCart();
            return cart.Sum(c => c.Quantity);
        }

        public Order CreateOrder(Order newOrder, string userId) {

            var cart = this.GetCart();

            newOrder.DateCreated = DateTime.Now;
            newOrder.UserID = userId;

            this.db.Orders.Add(newOrder);

            if (newOrder.OrderItems == null)
                newOrder.OrderItems = new List<OrderItem>();

            decimal cartTotal = 0;

            foreach(var cartItem in cart)
            {

                var newOrderItem = new OrderItem() {

                    BookId = cartItem.Book.BookID,
                    Quantity = cartItem.Quantity,
                    UnitPrice = cartItem.Book.Price

                };

                cartTotal += (cartItem.Quantity * cartItem.Book.Price);
                newOrder.OrderItems.Add(newOrderItem);
            }

            newOrder.TotalPrice = cartTotal;
            this.db.SaveChanges();

            return newOrder;
        }

        public void EmptyCart()
        {
            session.Set<List<CartItem>>(CartSessionKey, null);
        }

    }
}