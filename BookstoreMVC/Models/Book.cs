using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookstoreMVC.Models
{
    public class Book
    {
        public int BookID { get; set; }
        public int BookTypeID { get; set; }
        public string AuthorName { get; set; }
        public string Title { get; set; }
        public int Pages { get; set; }
        public DateTime DateAdded { get; set; }
        public string ImageFileName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsBestseller { get; set; }
        public bool IsHidden { get; set; }
        public bool IsNew { get; set; }
        public virtual BookType BookType { get; set; }
        
    }
}