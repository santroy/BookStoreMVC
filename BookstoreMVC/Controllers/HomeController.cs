using BookstoreMVC.DAL;
using BookstoreMVC.Infrastructure;
using BookstoreMVC.Models;
using BookstoreMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookstoreMVC.Controllers
{
    public class HomeController : Controller
    {
        private ShopContext db = new ShopContext();
        // GET: Home
        public ActionResult Index()
        {
            var bookTypes = db.BookTypes.ToList();

            List<Book> newBooks;

            ICacheProvider cache = new DefaultCacheProvider();
            if (cache.IsSet(Consts.NewItemsCacheKey))
            {
                newBooks = cache.Get(Consts.NewItemsCacheKey) as List<Book>;

            }
            else
            {
                newBooks = db.Books.Where(b => !b.IsHidden).OrderByDescending(b => b.DateAdded).Take(3).ToList();
                cache.Set(Consts.NewItemsCacheKey, newBooks, 30);
            }
           
            var bestsellers = db.Books.Where(b => !b.IsHidden && b.IsBestseller).OrderBy(b => Guid.NewGuid()).Take(3).ToList();
            var vm = new HomeViewModel()
            {
                Bestsellers = bestsellers,
                BookTypes = bookTypes,
                NewBooks = newBooks
            };

            return View(vm);
        }

        public ActionResult StaticContent(string viewname)
        {
            return View(viewname);
        }

    }
}