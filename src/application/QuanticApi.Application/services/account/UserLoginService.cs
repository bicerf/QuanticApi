using QuanticApi.Application.dtos.user;
using QuanticApi.Core.security;
using QuanticApi.Domain.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanticApi.Application.services.account
{
    public class UserLoginService : IUserLoginService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        public UserLoginService(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public UserLoginResponseDto OnProcess(UserLoginRequestDto request)
        {
            var user = _userRepository.FindUserByEmail(request.Email);
            var response = new UserLoginResponseDto();

            if (user == null)
            {
                response.ErrorMessage = "Kullanıcı hesabı bulunamadı";
                response.IsSucceeded = false;

            }
            else
            {
                var hashedPassword = _passwordHasher.HashPassword(request.Password);

                if (user.PasswordHash != hashedPassword)
                {
                    response.ErrorMessage = "Parola hatalı";
                    response.IsSucceeded = false;

                }
                else
                {
                    response.IsSucceeded = true;

                }

            }
            return response;




        }
    }
}
