using LinusNestorson_WebbShop.Database;
using Microsoft.IdentityModel.Tokens;
using System;

namespace LinusNestorson_WebbShop
{
    class Program
    {
        internal static void Main()
        {
            var webbshop = new WebbShopAPI();
            Seeder.GenerateData();
            var categoryList = webbshop.GetCategories();
            foreach (var category in categoryList)
            {
                Console.WriteLine(category.Name);
            }

        }

    }
}
