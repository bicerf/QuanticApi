﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanticApi.Application.dtos.user
{
    public class UserRegisterRequestDto
    {
        public string Email { get; set; }
        public string Password { get; set; }

    }
}