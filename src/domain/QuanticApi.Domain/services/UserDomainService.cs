using QuanticApi.Core.security;
using QuanticApi.Domain.models;
using QuanticApi.Domain.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanticApi.Domain.services
{
    public class UserDomainService : IUserDomainService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        public UserDomainService(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }
        public ApplicationUserResult CreateUser(string email, string password)
        {
            var result = new ApplicationUserResult() { IsSucceeded = true };

            //email unique mi ?
            var emailExists = _userRepository.GetQuery().FirstOrDefault(x => x.Email == email) == null ? false : true;
            if (emailExists)
            {
                result.Errors.Add("Aynı hesaptan sistemde mevcuttur!");
            }
            else
            { 
                

                var user = new ApplicationUser(email);
                //burada password'ü hashledik
                var hashedPassword = _passwordHasher.HashPassword(password);
                user.SetPasswordHash(hashedPassword);

                _userRepository.Add(user);
                _userRepository.Save();
                var dbUser = _userRepository.Find(user.Id);
                if (dbUser == null)
                {
                    result.Errors.Add("Hesap oluşturulamadı!");
                }
                result.IsSucceeded = result.Errors.Count() > 0 ? false : true;

            }
            return result;

        }

   
    }
}
