﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanticApi.Core.application
{
    public interface IApplicationService<in TRequest, out TResponse>
    {
        TResponse OnProcess(TRequest @request = default(TRequest));
    }
}
