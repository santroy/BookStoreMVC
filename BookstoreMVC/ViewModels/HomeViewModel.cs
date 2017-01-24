using BookstoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookstoreMVC.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Book> Bestsellers { get; set; }
        public IEnumerable<Book> NewBooks { get; set; }
        public IEnumerable<BookType> BookTypes { get; set; }

    }
}