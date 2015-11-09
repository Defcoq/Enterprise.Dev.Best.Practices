using EA.JP.Ecommerce.Infrastructure.Domain;
using EA.JP.Ecommerce.Model.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.JP.Ecommerce.Model.Products
{
    public class Product : EntityBase<int>, IAggregateRoot
    {
        public ProductSize Size { get; set; }

        public ProductTitle Title { get; set; }

        public string Name
        {
            get { return Title.Name; }
        }

        public Decimal Price
        {
            get { return Title.Price; }
        }

        public Brand Brand
        {
            get { return Title.Brand; }
        }

        public ProductColor Color
        {
            get { return Title.Color; }
        }

        public Category Category
        {
            get { return Title.Category; }
        }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
