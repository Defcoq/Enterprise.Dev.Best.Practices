using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using EA.DAL.QueryObject.Infrastructure.Query;
using System.Data.Entity.Core.Objects;

namespace EA.DAL.ORM.Library.Repository.EF.QueryTranslators
{
    public abstract class QueryTranslator
    {
        public void CreateQueryAndObjectParameters(Query query, StringBuilder queryBuilder, IList<ObjectParameter> paraColl)
        {          
            foreach (Criterion criterion in query.Criteria)
            {
                switch (criterion.criteriaOperator)
                {
                    case CriteriaOperator.Equal:
                        queryBuilder.Append(String.Format("it.{0} = @{0}", criterion.PropertyName));
                        break;
                    case CriteriaOperator.LessThanOrEqual:
                        queryBuilder.Append(String.Format("it.{0} <= @{0}", criterion.PropertyName));
                        break;
                    default:
                        throw new ApplicationException("No operator defined");
                }

                paraColl.Add(new ObjectParameter(criterion.PropertyName, criterion.Value));
            }
        }
    }
}
