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
                var user = context.Users.FirstOrDefault(u => u.Name == username && u.Password == password && u.IsActive);
                if (user != null)
                {
                    user.LastLogin = DateTime.Now;
                    user.SessionTimer = DateTime.Now;
                    context.Users.Update(user);
                    context.SaveChanges();
                    return user.Id;
                }
            }
            //Kontrollera om användare finns
            return 0; // 0 = user doesn't exist
        }
        public void Logout(int id)
        {
            var user = context.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                user.LastLogin = DateTime.MinValue;
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
        public List<Book> GetCategory()
        {
            return context.Books.OrderBy(b => b.Title).ToList();
        }
        public List<Book> GetAvailableBooks()
        {
            return context.Books.Where(b => b.Amount>0).OrderBy(b => b.Title).ToList();
        }
    }
}
