using QuanticApi.Application.dtos.user;
using QuanticApi.Application.validators;
using QuanticApi.Domain.repositories;
using QuanticApi.Domain.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanticApi.Application.services.account
{
    public class UserRegisterService : IUserRegisterService
    {
        private IUserDomainService _userManager;
        private IUserRegisterValidator _validator;
        private readonly IUserRepository _userRepository;

        public UserRegisterService(IUserDomainService userManager, IUserRegisterValidator validator, IUserRepository userRepository)
        {
            _userManager = userManager;
            _validator = validator;
            _userRepository = userRepository;
        }

        public UserRegisterResponseDto OnProcess(UserRegisterRequestDto request)
        {
            var response = new UserRegisterResponseDto();
            var validResult = _validator.IsValid(request);
            var user = _userRepository.FindUserByEmail(request.Email);


            if (validResult)
            {
                response.Success = true;
                var result = _userManager.CreateUser(request.Email, request.Password);


                if (result.IsSucceeded && user == null)
                {
                    response.Message = "Kullanıcı kaydı başarılıdır!";
                }
                else
                {
                    response.Message = string.Join(",","Bu hesap ile zaten üyelik mevcut!");
                    response.Success = false;
                }
            }
            else
            {
                response.Success = false;
                response.Message = string.Join(",", _validator.Errors);
            }
            return response;
            
        }
    }
}
