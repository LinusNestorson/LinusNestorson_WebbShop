using System;
using LinusNestorson_WebbShop.Database;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LinusNestorson_WebbShop.Helpers
{
    public class AdminHelper
    {
        private ShopContext context = new ShopContext();
        public bool IfAdmin(int adminId)
        {
            var user = context.Users.FirstOrDefault(u => u.Id == adminId);
            if (user.IsAdmin)
            {
                return true;
            }
            else return false;
        }
    }
}
