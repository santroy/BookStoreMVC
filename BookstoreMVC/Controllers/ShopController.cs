using BookstoreMVC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace BookstoreMVC.Controllers
{

    public class ShopController : Controller
    {
        private ShopContext db = new ShopContext();

        // GET: Shop
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var book = db.Books.Find(id);
            return View(book);
        }

        public ActionResult List(string booktype, string searchQuery = null)
        {
            var bookType = db.BookTypes.Include("Books").Where(t => t.Name.ToUpper() == booktype.ToUpper()).Single();
            //var books = bookType.Books.ToList();

            var books = bookType.Books.Where(b => (searchQuery == null ||
                                                    b.Title.ToLower().Contains(searchQuery.ToLower()) ||
                                                    b.AuthorName.ToLower().Contains(searchQuery.ToLower())) &&
                                                    !b.IsHidden);

            //var books = bookType.Books.Where(a => (searchQuery == null ||
            //                                    a.Title.ToLower().Contains(searchQuery.ToLower()) ||
            //                                    a.AuthorName.ToLower().Contains(searchQuery.ToLower())) &&
            //                                    !a.IsHidden);





            if (Request.IsAjaxRequest()) {
                return PartialView("_BookList", books);
               }

            return View(books);
        }

        [ChildActionOnly]
        [OutputCache(Duration = 80000)]
        public ActionResult BookTypeMenu() {

            var bookTypes = db.BookTypes.ToList();
            return PartialView("_BookTypeMenu", bookTypes);

        }

        public ActionResult BooksSuggestions(string term) {

            //var books = this.db.Books.Where(b => !b.IsHidden && 
            //b.Title.ToLower().Contains(term.ToLower())).Take(5).Select(b => new { label = b.Title });

            var books = this.db.Books.Where(a => a.Title.ToLower().Contains(term.ToLower()) &&
            !a.IsHidden).Take(5).Select(a => new { label = a.Title });

            return Json(books, JsonRequestBehavior.AllowGet);

        }

    }
}