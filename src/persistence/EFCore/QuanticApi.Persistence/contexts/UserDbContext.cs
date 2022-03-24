using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using QuanticApi.Domain.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanticApi.Persistence.contexts
{
    public class UserDbContextFactory : IDesignTimeDbContextFactory<UserDbContext>
    {
        
        public UserDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<UserDbContext>();
            optionsBuilder.UseSqlServer(@"Server=(LocalDB)\MSSQLLocalDB;Database=QuanticApi;Trusted_Connection=true");

            return new UserDbContext(optionsBuilder.Options);
        }
    }
    public class UserDbContext : DbContext
    {
        public DbSet<ApplicationUser> Users { get; set; }
  

        public UserDbContext(DbContextOptions<UserDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }
    }
}
