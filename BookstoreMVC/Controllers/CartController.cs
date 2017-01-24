using BookstoreMVC.App_Start;
using BookstoreMVC.DAL;
using BookstoreMVC.Infrastructure;
using BookstoreMVC.Models;
using BookstoreMVC.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BookstoreMVC.Controllers
{
    public class CartController : Controller
    {
        private ShoppingCartManager shoppingCartManager;
        private ISessionManager sessionManager { get; set; }
        private ShopContext db = new ShopContext(); 

        public CartController()
        {
            this.sessionManager = new SessionManager();
            this.shoppingCartManager = new ShoppingCartManager(this.sessionManager, this.db);


        }
        // GET: Cart
        public ActionResult Index()
        {
            var cartItems = shoppingCartManager.GetCart();
            var cartTotalPrice = shoppingCartManager.GetCartTotalPrice();

            CartViewModel cartVM = new CartViewModel() { CartItems = cartItems, TotalPrice = cartTotalPrice }; 

            return View(cartVM);
        }

        public ActionResult AddToCart(int id) {

            shoppingCartManager.AddToCart(id);
            return RedirectToAction("Index");

        }

        public decimal GetCartItemsCount() {
            return shoppingCartManager.GetCartItemCount();
        }

        public ActionResult RemoveFromCart(int bookID)
        {

            int itemCount = shoppingCartManager.RemoveFromCart(bookID);
            int cartItemsCount = shoppingCartManager.GetCartItemCount();
            decimal cartTotal = shoppingCartManager.GetCartTotalPrice();

            var result = new CartRemoveViewModel
            {
                RemoveItemId = bookID,
                RemovedItemCount = itemCount,
                CartTotal = cartTotal,
                CartItemsCount = cartItemsCount

            };

                return Json(result);

        }


        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {

            get { return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
            private set { _userManager = value;  }

        }


        public async Task<ActionResult> Checkout() {

            if (Request.IsAuthenticated)
            {

                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                var order = new Order
                {

                    FirstName = user.UserData.FirstName,
                    LastName = user.UserData.LastName,
                    Address = user.UserData.Address,
                    CityCode = user.UserData.CodeAndCity,
                    Email = user.UserData.Email,
                    PhoneNumber = user.UserData.PhoneNumber

                };

                return View(order);

            }
            else {

                return RedirectToAction("Login", "Account", new { returnUrl = Url.Action("Checkout", "Cart") });

            }

        }

        [HttpPost]
        public async Task<ActionResult> Checkout(Order orderdetails) {
            if(ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                var newOrder = shoppingCartManager.CreateOrder(orderdetails, userId);
                var user = await UserManager.FindByIdAsync(userId);
                TryUpdateModel(user.UserData);
                await UserManager.UpdateAsync(user);
                shoppingCartManager.EmptyCart();
                return RedirectToAction("OrderConfirmation");
            } else
            {

                return View(orderdetails);

            }
        }

        public ActionResult OrderConfirmation()
        {

            return View();

        }

    }
}