using BookstoreMVC.DAL;
using BookstoreMVC.Models;
using MvcSiteMapProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookstoreMVC.Infrastructure
{
    public class ProductDetailsDynamicNodeProvider : DynamicNodeProviderBase
    {
        private ShopContext db = new ShopContext();
        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {

            var returnValue = new List<DynamicNode>();

            foreach (Book b in db.Books) {
                DynamicNode n = new DynamicNode();
                n.Title = b.Title;
                n.Key = "Book_" + b.BookID;
                n.ParentKey = "BookType_" + b.BookTypeID;
                n.RouteValues.Add("id", b.BookID);
                returnValue.Add(n);
            }

            return returnValue;
        }
    }
}