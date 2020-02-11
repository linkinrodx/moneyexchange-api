using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Money_Exchange.API.Common;
using Money_Exchange.API.Infraestructure.Context;
using Money_Exchange.API.Models;
using Money_Exchange.API.ViewModels.Request;

namespace Money_Exchange.API.Infraestructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MoneyExchangeContext dbcontext;

        public UserRepository(MoneyExchangeContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public User Login(LoginRequest request)
        {
            var user = dbcontext.User.Where(o => 
                o.Username == request.Username && o.Password == Encryption.GetMD5(request.Password)
            ).FirstOrDefault();

            return user;
        }
    }
}
