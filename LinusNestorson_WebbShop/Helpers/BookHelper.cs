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
        public bool doesBookExist(int bookId)
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
