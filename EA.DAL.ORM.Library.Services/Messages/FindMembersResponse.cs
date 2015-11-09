using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EA.DAL.ORM.Library.Services.Views;

namespace EA.DAL.ORM.Library.Services.Messages
{
    public class FindMembersResponse : ResponseBase
    {
        public IEnumerable<MemberView> MembersFound { get; set; }
    }
}
