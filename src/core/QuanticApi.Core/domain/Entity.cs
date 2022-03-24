﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanticApi.Core.domain
{
    public abstract class Entity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
    }
}
