using BookstoreMVC.Migrations;
using BookstoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;

namespace BookstoreMVC.DAL
{
    public class ShopInitializer : MigrateDatabaseToLatestVersion<ShopContext, Configuration>
    {
        //protected override void Seed(ShopContext context)
        //{
        //    SeedStoreData(context);
        //    base.Seed(context);
        //}

        public static void SeedStoreData(ShopContext context)
        {
            var bookTypes = new List<BookType> {

                new BookType() { BookTypeID = 1 , Name = "Przyrodniczy" , Description = "Książki o zwierzętach, roślinach, itp..." , IconFileName = "ico_przyrodniczy.png" },
                new BookType() { BookTypeID = 2 , Name = "Historyczny" , Description = "Książki o wydarzeniach historycznych." , IconFileName = "ico_historyczny.png" },
                new BookType() { BookTypeID = 3 , Name = "Fantasy" , Description = "Książki o smokach, magii w średniowieczu." , IconFileName = "ico_fantasy.png" },
                new BookType() { BookTypeID = 4 , Name = "Horror" , Description = "Książki pobudzające strach." , IconFileName = "ico_horror.png" },
                new BookType() { BookTypeID = 5 , Name = "Dokumentalny" , Description = "Książki opisujące fakty." , IconFileName = "ico_dokumentalny.png" },
                new BookType() { BookTypeID = 6 , Name = "Komedia" , Description = "Książki że śmiesznymi wydarzeniami i momentami" , IconFileName = "ico_komedia.png" },
                new BookType() { BookTypeID = 7 , Name = "Tragedia" , Description = "Książki życiowe" , IconFileName = "ico_tragedia.png" },
                new BookType() { BookTypeID = 8 , Name = "Poradnik" , Description = "Ksiązki o ulepszaniu umiejętności" , IconFileName = "ico_poradnik.png" },
                new BookType() { BookTypeID = 9 , Name = "Naukowy" , Description = "Nudne książki" , IconFileName = "ico_naukowy.png" },
                new BookType() { BookTypeID = 10 , Name = "Przygodowy" , Description = "Książki uzależniające" , IconFileName = "ico_przygodowy.png" },
                new BookType() { BookTypeID = 11 , Name = "Psychologiczny" , Description = "Tych nie czytaj." , IconFileName = "ico_psychologiczny.png" },
                new BookType() { BookTypeID = 12 , Name = "Kryminał" , Description = "Książki o zabójstwach, mafii i innej patologii." , IconFileName = "ico_kryminał.png" },
                new BookType() { BookTypeID = 13 , Name = "Biografia" , Description = "Piszesz o mnie książkę? Tak." , IconFileName = "ico_biografia.png" }

            };

            bookTypes.ForEach(bt => context.BookTypes.AddOrUpdate(bt));
            context.SaveChanges();

            var books = new List<Book>
            {

                new Book() { BookID = 1, AuthorName = "Mróz Remigiusz", Title = "W kręgach władzy. Tom 1. Wotum nieufności", Pages = 200, Price = 25, ImageFileName = "cover_wotum.png", IsBestseller = false, DateAdded = new DateTime(2017,01,11), BookTypeID = 12, Description = "lorem10"  },
                new Book() { BookID = 2, AuthorName = "Wohlleben Peter", Title = "Sekretne życie drzew", Pages = 256, Price = 23, ImageFileName = "cover_sekretnezycie.png", IsBestseller = true, DateAdded = new DateTime(2016,09,14), BookTypeID = 5, Description = "lorem10" },
                new Book() { BookID = 3, AuthorName = "Hawkins Paula", Title = "Dziewczyna z pociągu", Pages = 328, Price = 23, ImageFileName = "cover_dziewczyna.png", IsBestseller = false, DateAdded = new DateTime(2016,09,14), BookTypeID = 12, Description = "lorem10"  },
                new Book() { BookID = 4, AuthorName = "Roberts Gregory David", Title = "Shantaram", Pages = 800, Price = 36, ImageFileName = "cover_shantaram.png", IsBestseller = false, DateAdded = new DateTime(2016,02,17), BookTypeID = 13, Description = "lorem10"  },
                new Book() { BookID = 5, AuthorName = "Rowling J. K.", Title = "Harry Potter i Przeklęte Dziecko", Pages = 320, Price = 25, ImageFileName = "cover_harrypotter.png", IsBestseller = true, DateAdded = new DateTime(2016,10,22), BookTypeID = 3, Description = "lorem10"  },
                new Book() { BookID = 6, AuthorName = "Robert L. Vitagliano", Title = "Slave In The Souls", Pages = 230, Price = 20, ImageFileName = "cover_slave.png", IsBestseller = false, DateAdded = new DateTime(2015,01,21), BookTypeID = 1, Description = "lorem10"  },
                new Book() { BookID = 7, AuthorName = "Frederic S. Bostic", Title = "Serpent Of Wizards", Pages = 134, Price = 25, ImageFileName = "cover_serpent.png", IsBestseller = true, DateAdded = new DateTime(2014,11,15), BookTypeID = 2, Description = "lorem10"  },
                new Book() { BookID = 8, AuthorName = "Carol J. Gonzales", Title = "Buffalo In The End", Pages = 542, Price = 40, ImageFileName = "cover_buffalo.png", IsBestseller = true, DateAdded = new DateTime(2016,04,10), BookTypeID = 4 , Description = "lorem10" },
                new Book() { BookID = 9, AuthorName = "Adam A. Vannest", Title = "The Death's Dying", Pages = 312, Price = 15, ImageFileName = "cover_death.png", IsBestseller = false, DateAdded = new DateTime(2017,06,04), BookTypeID = 6, Description = "lorem10"  },
                new Book() { BookID = 10, AuthorName = "Joyce J. Tryon", Title = "The Astro Mutant", Pages = 463, Price = 30, ImageFileName = "cover_astro.png", IsBestseller = false, DateAdded = new DateTime(2008,12,13), BookTypeID = 7, Description = "lorem10"  },
                new Book() { BookID = 11, AuthorName = "Morgan M. Nelson", Title = "The Shuttle's Lord", Pages = 231, Price = 56, ImageFileName = "cover_shuttle.png", IsBestseller = true, DateAdded = new DateTime(2002,05,19), BookTypeID = 8, Description = "lorem10"  },
                new Book() { BookID = 12, AuthorName = "Cristen G. Johnson", Title = "Flying In The Oak", Pages = 553, Price = 31, ImageFileName = "cover_oak.png", IsBestseller = false, DateAdded = new DateTime(2005,04,24), BookTypeID = 9, Description = "lorem10"  },
                new Book() { BookID = 13, AuthorName = "Kelly C. Brown", Title = "The Kiss Of The Word", Pages = 321, Price = 23, ImageFileName = "cover_word.png", IsBestseller = false, DateAdded = new DateTime(2012,07,30), BookTypeID = 10, Description = "lorem10"  },
                new Book() { BookID = 14, AuthorName = "William P. Thomas", Title = "The Silent Thorn", Pages = 211, Price = 19, ImageFileName = "cover_thorn.png", IsBestseller = true, DateAdded = new DateTime(2013,02,01), BookTypeID = 11, Description = "lorem10"  }

            };

            books.ForEach(b => context.Books.AddOrUpdate(b));
            context.SaveChanges();

        }
    }
}