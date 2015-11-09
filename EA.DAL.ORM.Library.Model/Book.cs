using EA.DAL.ORM.Library.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.DAL.ORM.Library.Model
{
    public class Book : IAggregateRoot
    {
        public Guid Id { get; set; }

        public virtual BookTitle Title { get; set; }

        public virtual Member OnLoanTo { get; set; }

    }
}
