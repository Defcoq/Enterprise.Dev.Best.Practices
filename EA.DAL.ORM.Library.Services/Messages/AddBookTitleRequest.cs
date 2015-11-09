using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EA.DAL.ORM.Library.Services.Messages
{
    public class AddBookTitleRequest
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
    }
}
