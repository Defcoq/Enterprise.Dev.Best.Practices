using EA.JP.Ecommerce.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.JP.Ecommerce.Model.Products
{
    public interface IProductTitleRepository : IReadOnlyRepository<ProductTitle, int>
    {
    }
}
