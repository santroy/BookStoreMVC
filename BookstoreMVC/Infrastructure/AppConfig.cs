using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace BookstoreMVC.Infrastructure
{
    public class AppConfig
    {
        private static string _bookTypeIconFolderRelative = ConfigurationManager.AppSettings["BookTypeIconsFolder"];
        private static string _ImageFolderRelative = ConfigurationManager.AppSettings["ImageFolder"];

        public static string BookTypeIconsFolderRelative
        {
            get
            {
                return _bookTypeIconFolderRelative;
            }
        }

        public static string ImageFolderRelative
        {
            get
            {
                return _ImageFolderRelative;
            }
        }


    }
}