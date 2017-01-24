using BookstoreMVC.DAL;
using BookstoreMVC.Models;
using MvcSiteMapProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookstoreMVC.Infrastructure
{
    public class ProductListDynamicNodeProvider : DynamicNodeProviderBase
    {
        private ShopContext db = new ShopContext();
        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {

            var returnValue = new List<DynamicNode>();

            foreach (BookType b in db.BookTypes)
            {
                DynamicNode n = new DynamicNode();
                n.Title = b.Name;
                n.Key = "BookType_" + b.BookTypeID;
                n.RouteValues.Add("booktype", b.Name);
                returnValue.Add(n);
            }

            return returnValue;
        }
    }
}