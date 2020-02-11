using System;
using Xunit;
using System.Net.Http;
using Newtonsoft.Json;
using Money_Exchange.API.ViewModels.Response;
using Money_Exchange.API.ViewModels.Result;

namespace Money_Exchange.Test
{
    public class MoneyExchangeTest
    {
        private readonly HttpClient Client;

        public MoneyExchangeTest()
        {
            Client = new HttpClient();
        }

        [Fact]
        public async System.Threading.Tasks.Task LoginTest()
        {
            // Arrange
            var request = new
            {
                Url = "http://appscurrencyexchangeeu2.azurewebsites.net/api/Security/Login",
                Body = new
                {
                    username = "admin",
                    password = "admin"
                }
            };

            // Act
            var response = await Client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var value = await response.Content.ReadAsStringAsync();
            var singleResponse = JsonConvert.DeserializeObject<ResponseEntity<UserResult>>(value);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.NotNull(singleResponse.result);
        }

        [Fact]
        public async System.Threading.Tasks.Task ExchangeTest()
        {
            // Arrange
            var request = new
            {
                Url = "http://appscurrencyexchangeeu2.azurewebsites.net/api/Currency/Exchange",
                Body = new
                {
                    userId = 1,
                    startCurrencyId = (int)API.Common.Enum.CurrencyType.USD,
                    targetCurrencyId = (int)API.Common.Enum.CurrencyType.EUR,
                    startValue = 100
                }
            };

            // Act
            var response = await Client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var value = await response.Content.ReadAsStringAsync();
            var singleResponse = JsonConvert.DeserializeObject<ResponseEntity<QueryResult>>(value);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.NotNull(singleResponse.result);
        }
    }
}
