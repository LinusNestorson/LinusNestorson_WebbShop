using LinusNestorson_WebbShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace LinusNestorson_WebbShop.Database
{
    public static class Seeder
    {

        static public void GenerateData()
        {
            FillUser("Administrator", "CodicRulez", true);
            FillUser("TestClient", "Codic2021", false);
            FillBook("Cabal (Nightbreed)", "Clive Barker", 250, 3, 1);
            FillBook("The Shining", "Stephen King", 200, 2, 1);
            FillBook("Doctor Sleep", "Stephen King", 200, 1, 1);
            FillBook("I Robot", "Isaac Asimov", 150, 4, 3);
            FillCategory("Horror");
            FillCategory("Humor");
            FillCategory("Science Fiction");
            FillCategory("Romance");
        }
        public static void FillUser(string name, string password, bool isAdmin)
        {
            using ( var db = new ShopContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Name == name);
                if (user == null)
                {
                    user = new User { Name = name, Password = password, IsAdmin = isAdmin };
                    db.Update(user);
                    db.SaveChanges();
                }

            }
        }
        public static void FillBook(string title, string author, int price, int amount, int categoryId)
        {
            using (var db = new ShopContext())
            {
                var book = db.Books.FirstOrDefault(b => b.Title == title);
                if (book == null)
                {
                    book = new Book { Title = title, Author = author, Price = price, Amount = amount, CategoryId = categoryId };
                    db.Update(book);
                    db.SaveChanges();
                }

            }
        }
        public static void FillCategory(string name)
        {
            using (var db = new ShopContext())
            {
                var category = db.Categories.FirstOrDefault(c => c.Name == name);
                if (category == null)
                {
                    category = new Category { Name = name };
                    db.Update(category);
                    db.SaveChanges();
                }

            }
        }
    }
}
