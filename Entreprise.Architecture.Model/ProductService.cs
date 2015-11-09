using Entreprise.Architecture.BBL.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entreprise.Architecture.Model
{
    public class ProductService
    {
        private IProductRepository<Product> _productRepository;

        public ProductService(IProductRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public IList<Product> GetAllProductsFor(CustomerType customerType)
        {
            IDiscountStrategy discountStrategy = DiscountFactory.GetDiscountStrategyFor(customerType);
            IList<Product> products = _productRepository.FindAll();

            products.Apply(discountStrategy);

            return products;
        }
    }
}
