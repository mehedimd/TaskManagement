﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Services.Interfaces
{
    public interface IUserService
    {
        string GetCurrentUserId { get; }
    }
}
