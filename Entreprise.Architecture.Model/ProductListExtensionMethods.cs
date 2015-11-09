using Entreprise.Architecture.BBL.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entreprise.Architecture.Model
{
    public static class ProductListExtensionMethods
    {
        public static void Apply(this IList<Product> products,IDiscountStrategy discountStrategy)
        {
            foreach (Product p in products)
            {
                p.Price.SetDiscountStrategyTo(discountStrategy);
            }
        }
    }

}
