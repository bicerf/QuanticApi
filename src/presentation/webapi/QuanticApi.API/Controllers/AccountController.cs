using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanticApi.Application.dtos.user;
using QuanticApi.Application.services.account;
using QuanticApi.Domain.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanticApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserRegisterService _userRegisterService;
        private readonly IUserLoginService _userLoginService;
        private readonly IUserRepository _userRepository;



        public AccountController(IUserRegisterService userRegisterService, IUserLoginService userLoginService,IUserRepository userRepository)
        {
            _userRegisterService = userRegisterService;
            _userLoginService = userLoginService;
            _userRepository = userRepository;

        }

        [HttpGet("getallusers")]
        public IActionResult GetAll()
        {
            var response = _userRepository.GetQuery();
            return Ok(response);
        }

        [HttpPost("createuser")]
        public IActionResult CreateUser([FromBody] UserRegisterRequestDto model)
        {
            var response = _userRegisterService.OnProcess(model);
            return Ok(response);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginRequestDto model)
        {
            var response = _userLoginService.OnProcess(model);
            if (response.IsSucceeded)
            {
                
                return Ok(response.IsSucceeded);

            }
            else
            {
                return BadRequest(response.ErrorMessage);
            }

        }
    }
}
