using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Money_Exchange.API.ViewModels.Request
{
    public class ExchangeRequest
    {
        public int UserId { get; set; }
        public int StartCurrencyId { get; set; }
        public int TargetCurrencyId { get; set; }
        public decimal StartValue { get; set; }
    }
}
