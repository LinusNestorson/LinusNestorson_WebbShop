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
        /// <summary>
        /// See if user exist in database based on name.
        /// </summary>
        /// <param name="name">Name of user</param>
        /// <returns>True if user exist, false if not</returns>
        public bool DoesUserExist(string name)
        {
            var user = context.Users.FirstOrDefault(u => u.Name == name);
            if (user != null)
            {
                return true;
            }
            
            else return false;
        }
        /// <summary>
        /// Overloaded mothed of DoesUserExist above. See if user exist in database based in Id.
        /// </summary>
        /// <param name="userId">Id of user</param>
        /// <returns>True if user exist, false if not</returns>
        public bool DoesUserExist(int userId)
        {
            var user = context.Users.FirstOrDefault(u => u.Id == userId);
            if (user != null)
            {
                return true;
            }
            else return false;
        }
        public bool CheckSessionTimer(int userId)
        {
            var user = context.Users.FirstOrDefault(u => u.Id == userId);
            if (DateTime.Now < user.SessionTimer)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
