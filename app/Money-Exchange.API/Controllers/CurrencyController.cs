using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using AutoMapper;
using Money_Exchange.API.Infraestructure.Repository;
using Money_Exchange.API.ViewModels.Response;
using Money_Exchange.API.ViewModels.Request;
using Money_Exchange.API.ViewModels.Result;

namespace Money_Exchange.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyRepository currencyRepository;
        private readonly IMapper mapper;

        public CurrencyController(ICurrencyRepository currencyRepository, IMapper mapper)
        {
            this.currencyRepository = currencyRepository;
            this.mapper = mapper;
        }

        [HttpPost]
        public ResponseEntity<QueryResult> Exchange(ExchangeRequest request)
        {
            var query = currencyRepository.Exchange(request);
            QueryResult queryResult = mapper.Map<QueryResult>(query);

            return ResponseEntity<QueryResult>.Create(queryResult);
        }
    }
}