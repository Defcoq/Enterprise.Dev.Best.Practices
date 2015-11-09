using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entreprise.Architecture.BBL.Contract
{
    public interface IDiscountStrategy
    {
        decimal ApplyExtraDiscountsTo(decimal OriginalSalePrice);
    }

}
