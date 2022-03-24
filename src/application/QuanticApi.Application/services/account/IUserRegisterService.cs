using QuanticApi.Application.dtos.user;
using QuanticApi.Core.application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanticApi.Application.services.account
{
    public interface IUserRegisterService:IApplicationService<UserRegisterRequestDto,UserRegisterResponseDto>
    {
    }
}
