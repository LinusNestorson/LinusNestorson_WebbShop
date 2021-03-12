using LinusNestorson_WebbShop.Database;
using LinusNestorson_WebbShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinusNestorson_WebbShop.Helpers
{
    public class UserHelper
    {
        private ShopContext context = new ShopContext();
        public User GetUser(int userId)
        {
            using (var context = new ShopContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Id == userId);
                return user;
            }
        }
        public bool doesUserExist(string name)
        {
            var user = context.Users.FirstOrDefault(u => u.Name == name);
            if (user != null)
            {
                return true;
            }
            else return false;
        }
    }
}
