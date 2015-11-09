using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.JP.Ecommerce.Services.ViewModels
{
    public class ProductView
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public IEnumerable<ProductSizeOption> Products { get; set; }

    }
}
