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
    public class SecurityController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public SecurityController(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        [HttpPost]
        public ResponseEntity<UserResult> Login(LoginRequest request)
        {
            var user = userRepository.Login(request);
            UserResult userResult = mapper.Map<UserResult>(user);

            return ResponseEntity<UserResult>.Create(userResult);
        }
    }
}