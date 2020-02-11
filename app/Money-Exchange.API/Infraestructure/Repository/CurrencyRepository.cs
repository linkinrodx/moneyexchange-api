using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Money_Exchange.API.Infraestructure.Context;
using Money_Exchange.API.Models;
using Money_Exchange.API.ViewModels.Request;
using Money_Exchange.API.ViewModels.Result;

namespace Money_Exchange.API.Infraestructure.Repository
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly MoneyExchangeContext dbcontext;

        public CurrencyRepository(MoneyExchangeContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public Query Exchange(ExchangeRequest request)
        {
            var now = DateTime.UtcNow;

            var valueTarget = dbcontext.CurrencyValue.Where(o => o.CurrencyId == request.TargetCurrencyId && o.StartDate <= now).OrderByDescending(o=> o.StartDate).FirstOrDefault();

            var newValue = Math.Round(request.StartValue * valueTarget.PurchaseValue, 4);

            var query = new Query
            {
                Guid = Guid.NewGuid().ToString(),
                UserId = request.UserId,
                StartCurrencyId = request.StartCurrencyId,
                TargetCurrencyId = request.TargetCurrencyId,
                StartValue = request.StartValue,
                TargetValue = newValue,
                QueryDate = now
            };

            dbcontext.Query.Add(query);
            dbcontext.SaveChanges();

            return query;
        }
    }
}
