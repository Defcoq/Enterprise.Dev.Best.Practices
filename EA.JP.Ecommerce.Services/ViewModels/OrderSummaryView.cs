using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EA.JP.Ecommerce.Services.ViewModels
{
    public class OrderSummaryView
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public bool IsSubmitted { get; set; }
    }

}
