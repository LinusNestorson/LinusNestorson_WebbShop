using LinusNestorson_WebbShop.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using LinusNestorson_WebbShop.Models;
using System.Dynamic;

namespace LinusNestorson_WebbShop
{
    public class WebbShopAPI
    {
        private ShopContext context = new ShopContext();
        public int Login(string username, string password)
        {
            {
                var user = context.Users.FirstOrDefault(u => u.Name == username && u.Password == password); // Lägg till && IsActive == True
                if (user != null)
                {
                    user.IsActive = true;
                    user.LastRefresh = DateTime.Now;
                    user.SessionTimer = user.LastRefresh.AddMinutes(15);
                    context.Users.Update(user);
                    context.SaveChanges();
                    return user.Id;
                }
            }
            //Kontrollera om användare finns
            return 0; // 0 = user doesn't exist
        }
        public void Logout(int userId)
        {
            var user = context.Users.FirstOrDefault(u => u.Id == userId);
            if (user != null)
            {
                user.IsActive = false;
                user.LastRefresh = DateTime.MinValue;
                context.Users.Update(user);
                context.SaveChanges();
            }
        }
        public List<Category> GetCategories()
        {
            return context.Categories.OrderBy(c => c.Name).ToList();
        }
        public List<Category> GetCategories(string keyword)
        {
            return context.Categories.Where(c => c.Name.Contains(keyword)).ToList();
        }
        public List<Book> GetCategory(int categoryId)
        {
            return context.Books.Where(b => b.Category.Id == categoryId).OrderBy(b => b.Title).ToList();
        }
        public List<Book> GetAvailableBooks()
        {
            return context.Books.Where(b => b.Amount>0).OrderBy(b => b.Title).ToList();
        }
        public string GetBook(int bookId)
        {
            var book = context.Books.Include("Category").FirstOrDefault(b => b.Id == bookId);
            return $"Book Title: {book.Title}\nAuthor: {book.Author}\nCategory: {book.Category.Name}\nPrice: {book.Price}\nAmount in stock: {book.Amount}";
        }
        public List<Book> GetBooks(string keyword)
        {
            return context.Books.Where(b => b.Title.Contains(keyword)).ToList();
        }
        public List<Book> GetAuthors(string keyword)
        {
            return context.Books.Where(b => b.Author.Contains(keyword)).ToList();
        }
        public bool BuyBook(int userId, int bookId) // Kontrollera denna
        {
            var user = context.Users.FirstOrDefault(u => u.Id == userId);
           
            if (user.OwnedBooks == null)
            {
                user.OwnedBooks = new List<SoldBook>();
            }
            var book = context.Books.FirstOrDefault(b => b.Id == bookId);

            if (book != null)
            {
                var soldBook = new SoldBook() { Title = book.Title, Author = book.Author, User = user, Category = book.Category, Price = book.Price, PurchasedDate = DateTime.Now };
                user.OwnedBooks.Add(soldBook);
                context.Users.Update(user);
                context.SaveChanges();
                return true;
            }
            else return false;
        }
        public string Ping(int userId) //Implemitera i varje stycke av Main
        {
            var user = context.Users.FirstOrDefault(u => u.Id == userId);
            if (DateTime.Now < user.SessionTimer)
            {
                user.LastRefresh = DateTime.Now;
                user.SessionTimer = user.LastRefresh.AddMinutes(15);
                context.Users.Update(user);
                context.SaveChanges();
                return "Pong";
            }
            else return string.Empty;
        }
        public bool Register(string name, string password, string verPassword)
        {
            var user = context.Users.FirstOrDefault(u => u.Name == name);
            if (user == null && password == verPassword)
            {
                user = new User() { Name = name, Password = password };
                context.Users.Update(user);
                context.SaveChanges();
                return true;
            }
            else if (password != verPassword)
            {
                return false;
            }
            else return false;
        }
    }
}
