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
        public User GetUser(int userId)
        {
            using (var context = new ShopContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Id == userId);
                return user;
            }
        }
    }
}
