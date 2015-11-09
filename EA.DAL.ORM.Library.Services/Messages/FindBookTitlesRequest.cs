using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EA.DAL.ORM.Library.Services.Messages
{
    public class FindBookTitlesRequest
    {       
        public string ISBN { get; set; }
        public bool All { get; set; }
    }
}
