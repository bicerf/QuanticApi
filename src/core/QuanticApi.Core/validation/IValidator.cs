using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanticApi.Core.validation
{
    public interface IValidator<TObject> where TObject:class, new()
    {
        //Validasyon hatalarını gösteririz
        List<string> Errors { get; set; }

        bool IsValid(TObject @object);
    }
}
