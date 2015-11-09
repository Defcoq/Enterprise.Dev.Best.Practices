using EA.JP.Ecommerce.Infrastructure.UnitOfWork;
using EA.JP.Ecommerce.Model.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.JP.Ecommerce.Repository.NH.Repositories
{
    public class ProductTitleRepository : Repository<ProductTitle, int>,
                                                           IProductTitleRepository
    {
        public ProductTitleRepository(IUnitOfWork uow)
            : base(uow)
        {
        }
    }
}
