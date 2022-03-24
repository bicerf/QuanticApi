using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanticApi.Core.domain
{
    //Uygulama içerisindeki Entity logiclerimizi DomainService ile yöneteceğiz
    public interface IDomainService<TEntity> where TEntity:Entity
    {
    }
}
