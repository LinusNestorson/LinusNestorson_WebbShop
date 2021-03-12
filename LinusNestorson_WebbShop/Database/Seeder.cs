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
            FillCategory("Horror");
            FillCategory("Humor");
            FillCategory("Science Fiction");
            FillCategory("Romance");
            FillBook("Cabal (Nightbreed)", "Clive Barker", 250, 3, "Horror");
            FillBook("The Shining", "Stephen King", 200, 2, "Horror");
            FillBook("Doctor Sleep", "Stephen King", 200, 1, "Horror");
            FillBook("I Robot", "Isaac Asimov", 150, 4, "Science Fiction");
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
        public static void FillBook(string title, string author, int price, int amount, string category)
        {
            using (var db = new ShopContext())
            {
                var book = db.Books.FirstOrDefault(b => b.Title == title);
                if (db.Books.Count() == 0)
                {
                    book = new Book { Title = title, Author = author, Price = price, Amount = amount, Category = db.Categories.FirstOrDefault(c => c.Name == category) };
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
