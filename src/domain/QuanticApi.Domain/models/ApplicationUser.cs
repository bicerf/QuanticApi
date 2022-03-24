using QuanticApi.Core.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanticApi.Domain.models
{
    public class ApplicationUser:Entity
    {
        public string UserName { get; private set; }
        
        public string Email { get; private set; }

        public string PasswordHash { get; private set; }


        public ApplicationUser(string email)
        {
            Id = Guid.NewGuid().ToString();
            SetEmail(email);
            SetUserName(email);
        }

      
        public void SetUserName(string username)
        {

            if (string.IsNullOrEmpty(username))
            {
                this.UserName = this.Email;
            }

            this.UserName = username.Trim();
        }

     
        public void SetEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new Exception("E-posta boş geçilemez");
            }

            this.Email = email.Trim();
        }

        public void SetPasswordHash(string passwordHash)
        {
            if (string.IsNullOrEmpty(passwordHash))
            {
                throw new Exception("Parola alanı boş geçilemez");
            }

            this.PasswordHash = passwordHash.Trim();
        }

  

    }
}
