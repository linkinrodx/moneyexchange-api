using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Money_Exchange.API.ViewModels.Result
{
    public class QueryResult
    {
        public int QueryId { get; set; }
        public string Guid { get; set; }
        public int? UserId { get; set; }
        public int StartCurrencyId { get; set; }
        public int TargetCurrencyId { get; set; }
        public decimal StartValue { get; set; }
        public decimal TargetValue { get; set; }
        public DateTime QueryDate { get; set; }
    }
}
