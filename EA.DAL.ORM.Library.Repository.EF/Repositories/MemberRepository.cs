using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using EA.DAL.ORM.Library.Model;
using EA.DAL.ORM.Library.Infrastructure;
using EA.DAL.ORM.Library.Infrastructure.UnitOfWork;
using EA.DAL.ORM.Library.Repository.EF.QueryTranslators;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;

namespace EA.DAL.ORM.Library.Repository.EF.Repositories
{
    public class MemberRepository : Repository<Model.Member, Guid>, IMemberRepository
    {
        public MemberRepository(IUnitOfWork uow) : base(uow)
        { }

        public override Model.Member FindBy(Guid Id)
        {
            return GetObjectSet().FirstOrDefault<Model.Member>(m => m.Id == Id);
        }

        public override IQueryable<Model.Member> GetObjectSet()
        {
            var objectContext = ((IObjectContextAdapter)DataContextFactory.GetDataContext()).ObjectContext;
            return objectContext.CreateObjectSet<Model.Member>(); ;
        }

        public override string GetEntitySetName()
        {
            return "Members";
        }

        public override ObjectQuery<Model.Member> TranslateIntoObjectQueryFrom(EA.DAL.QueryObject.Infrastructure.Query.Query query)
        {
            return new MemberQueryTranslator().Translate(query); 
        }
    }        
}
