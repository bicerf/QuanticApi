using QuanticApi.Application.dtos.user;
using QuanticApi.Core.validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanticApi.Application.validators
{
    public interface IUserRegisterValidator:IValidator<UserRegisterRequestDto>
    {
    }
}
