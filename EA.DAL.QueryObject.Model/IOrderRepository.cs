using EA.DAL.QueryObject.Infrastructure.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.DAL.QueryObject.Model
{
    public interface IOrderRepository
    {
        IEnumerable<Order> FindBy(Query query);
        IEnumerable<Order> FindBy(Query query, int index, int count);
    }
}
