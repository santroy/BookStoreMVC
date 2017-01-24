using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookstoreMVC.Infrastructure
{
    public static class UrlHelpers
    {
        public static string TypeIconPath(this UrlHelper helper, string typeIconFileName )
        {
            var typeIconFolder = AppConfig.BookTypeIconsFolderRelative;
            var path = Path.Combine(typeIconFolder, typeIconFileName);
            var absolutePath = helper.Content(path);
            return absolutePath;
        }

        public static string BookCoverPath(this UrlHelper helper, string coverIconFileName)
        {
            var coverFolder = AppConfig.ImageFolderRelative;
            var path = Path.Combine(coverFolder, coverIconFileName);
            var absolutePath = helper.Content(path);
            return absolutePath;
        }
    }
}