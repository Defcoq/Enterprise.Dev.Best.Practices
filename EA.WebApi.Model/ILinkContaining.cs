using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EA.WebApi.Model
{
    public interface ILinkContaining
    {
        List<Link> Links { get; set; }
        void AddLink(Link link);
    }

}