using QuanticApi.Core.data;
using QuanticApi.Domain.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanticApi.Domain.repositories
{
    public interface IUserRepository : IRepository<ApplicationUser>
    {
        ApplicationUser FindUserByEmail(string email);
    }
}
