using QuanticApi.Core.data;
using QuanticApi.Domain.models;
using QuanticApi.Domain.repositories;
using QuanticApi.Persistence.contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanticApi.Persistence.repositories
{
    public class EFUserRepository : EFBaseRepository<ApplicationUser, UserDbContext>, IUserRepository
    {
        public EFUserRepository(UserDbContext dbContext) : base(dbContext)
        {

        }

        public ApplicationUser FindUserByEmail(string email)
        {
            return _dbSet.FirstOrDefault(x => x.Email == email);
        }
    }
}
