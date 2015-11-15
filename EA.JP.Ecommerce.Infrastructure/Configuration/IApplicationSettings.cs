using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.JP.Ecommerce.Infrastructure.Configuration
{
    public interface IApplicationSettings
    {
        string LoggerName { get; }
        string NumberOfResultsPerPage { get; }
        string JanrainApiKey { get; }

        string PayPalBusinessEmail { get; }
        string PayPalPaymentPostToUrl { get; }
    }
}
