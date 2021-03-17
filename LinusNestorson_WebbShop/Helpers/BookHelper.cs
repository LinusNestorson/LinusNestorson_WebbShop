using System;
using LinusNestorson_WebbShop.Database;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LinusNestorson_WebbShop.Helpers
{
    public class BookHelper
    {
        private ShopContext context = new ShopContext();
        /// <summary>
        /// Method to see if book exist in database.
        /// </summary>
        /// <param name="bookId">Id of the specific book</param>
        /// <returns>True if book exist, false if not</returns>
        public bool DoesBookExist(int bookId)
        {
            var book = context.Books.FirstOrDefault(b => b.Id == bookId);
            if (book != null)
            {
                return true;
            }
            else return false;
        }
    }
}
