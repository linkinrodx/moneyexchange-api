using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;
using Money_Exchange.API.Models;
using Money_Exchange.API.ViewModels.Result;

namespace Money_Exchange.API.Common
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<User, UserResult>();
            CreateMap<Query, QueryResult>();
        }
    }
}
