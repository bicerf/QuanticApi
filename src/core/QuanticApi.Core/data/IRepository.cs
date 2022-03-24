using QuanticApi.Core.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanticApi.Core.data
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        void Add(TEntity entity);
        void Remove(string Id);
        void Update(TEntity entity);

        TEntity Find(string Id);

        IQueryable<TEntity> GetQuery();

        IQueryable GetSqlRawQuery(string query);

        void Save();
    }
}
