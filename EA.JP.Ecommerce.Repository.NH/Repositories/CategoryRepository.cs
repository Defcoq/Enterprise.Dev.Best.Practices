using EA.JP.Ecommerce.Infrastructure.UnitOfWork;
using EA.JP.Ecommerce.Model.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.JP.Ecommerce.Repository.NH.Repositories
{
    public class CategoryRepository : Repository<Category, int>, ICategoryRepository
    {
        public CategoryRepository(IUnitOfWork uow)
            : base(uow)
        {
        }
    }
}
