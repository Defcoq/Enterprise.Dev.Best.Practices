using Entreprise.Architecture.BBL.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entreprise.Architecture.Repository
{
   public  class ProductRepository : IProductRepository<Model.Product>
    {
        public IList<Model.Product> FindAll()
        {
            var products = from p in new ShopDataContext().Products
                           select new Model.Product
                           {
                               Id = p.ProductId,
                               Name = p.ProductName,
                               Price = new Model.Price(p.RRP, p.SellingPrice)
                           };

            return products.ToList();
        }
    }
}
