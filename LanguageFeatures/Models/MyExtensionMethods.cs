using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace LanguageFeatures.Models
{
    public static class MyExtensionMethods
    {
        public static decimal TotalPrices(this IEnumerable<Product> products)
        {
            decimal total = 0;
            foreach (Product product in products)
                total += product?.Price ?? 0;
            return total;
        }

        public static IEnumerable<Product> Filter(this IEnumerable<Product> productEnum, Func<Product, bool> selector)
        {
            foreach (Product product in productEnum)
                if (selector(product))
                    yield return product;
        }
    }
}