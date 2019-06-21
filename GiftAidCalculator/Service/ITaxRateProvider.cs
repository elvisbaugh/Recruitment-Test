using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftAidCalculator.Service
{
    public interface ITaxRateProvider
    {
        decimal GetTaxRate();
    }
}
