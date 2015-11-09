using EA.DAL.ORM.Library.Infrastructure.UnitOfWork;
using EA.DAL.ORM.Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.DAL.ORM.Library.Repository.NH.Repositories
{
    public class MemberRepository : Repository<Member, Guid>, IMemberRepository
    {
        public MemberRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        { }
    }
}
