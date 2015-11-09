using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.DAL.ORM.Library.Services.Views
{
    public class BookView
    {
        public string Id { get; set; }

        public string ISBN { get; set; }

        public string Title { get; set; }

        public string OnLoanTo { get; set; }
    }
}
