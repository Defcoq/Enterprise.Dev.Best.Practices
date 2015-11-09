using EA.JP.Ecommerce.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.JP.Ecommerce.Model.Categories
{

    public interface ICategoryRepository : IReadOnlyRepository<Category, int>
    {
    }
}
