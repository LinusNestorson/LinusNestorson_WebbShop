using LinusNestorson_WebbShop.Database;
using LinusNestorson_WebbShop.Helpers;
using LinusNestorson_WebbShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Linq;

namespace LinusNestorson_WebbShop
{
    class Program
    {
        internal static void Main()
        {
            var webbshop = new WebbShopAPI();
            var adminOptions = new AdminAPI();
            var userHelper = new UserHelper();
            
            Seeder.GenerateData();
            var userId = webbshop.Login("Administrator", "CodicRulez");

            if (userId != 0)
            {
                Console.WriteLine("Login succeeded");
            }
            else
            {
                Console.WriteLine("Login failed");
                return; // Hur hantera detta?
            }

            adminOptions.AddBookToCategory(1, 2, 3);
            
            //adminOptions.DeleteBook(userId, 1);
            
            //adminOptions.UpdateBook(userId, 1, "BongoBoos Äventyr", "Sunil", 579);

            //foreach (var user in adminOptions.FindUser(userId, "Test"))
            //{
            //    Console.WriteLine($"{user.Name}");
            //}

            //foreach (var user in adminOptions.ListUsers(userId))
            //{
            //    Console.WriteLine($"{user.Name}");
            //}

            //adminOptions.SetAmount(userId, 1, 5);

            //adminOptions.AddBook(userId, "Twilight", "Stephanie Mayer", 79, 3);

            //if (webbshop.Register("Juice", "Apelsin", "Apelsin"))
            //{
            //    using (var context = new ShopContext())
            //    {
            //        var user = context.Users.FirstOrDefault(u => u.Name == "Juice");
            //        Console.WriteLine($"Welcome {user.Name}!");
            //    }
            //}

            //int userId = webbshop.Login("TestClient", "Codic2021");
            //User user = userHelper.GetUser(userId);

            //Console.WriteLine($"Welcome {user.Name}");
            //Console.WriteLine(webbshop.GetBook(2));

            //var categoryList = webbshop.GetCategories();
            //foreach (var category in categoryList)
            //{
            //    Console.WriteLine(category.Name);
            //}

            //var bookList = webbshop.GetBooks("or");
            //foreach (var book in bookList)
            //{
            //    Console.WriteLine(book.Title);
            //}

            //var authorBookList = webbshop.GetAuthors("st");
            //foreach (var book in authorBookList)
            //{
            //    Console.WriteLine(book.Title);
            //}

            //webbshop.BuyBook(2, 1); //<----Lägg till någon text om att köpet var lyckat if metod == true
            //{
            //    using (var context = new ShopContext())
            //    {
            //        foreach (var user in context.Users)
            //        {
            //            Console.WriteLine($"User: {user.Name}");

            //            var bookContext = new ShopContext();
            //            var boughtBooks = bookContext.SoldBooks.Where(b => b.User == user).ToList();
            //            if (boughtBooks.Count() != 0)
            //            {
            //                foreach (var book in boughtBooks)
            //                {
            //                    Console.WriteLine($"Bought: {book.Title}");
            //                }
            //            }
            //        }
            //    }
            //}

        }

    }
}
