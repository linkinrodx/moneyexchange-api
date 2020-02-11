using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Money_Exchange.API.Models;
using Money_Exchange.API.ViewModels.Request;

namespace Money_Exchange.API.Infraestructure.Repository
{
    public interface ICurrencyRepository
    {
        Query Exchange(ExchangeRequest request);
    }
}
