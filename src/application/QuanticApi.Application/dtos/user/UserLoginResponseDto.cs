using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanticApi.Application.dtos.user
{
    public class UserLoginResponseDto
    {
        public string ErrorMessage { get; set; } // işlem başarılı değilse döneceğimiz değer 
        public bool IsSucceeded { get; set; } // giriş işleminin başarılı olup olmadığı bilgisi
    }
}
