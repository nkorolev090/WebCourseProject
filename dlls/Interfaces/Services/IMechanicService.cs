﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.DTO;

namespace Interfaces.Services
{
    public interface IMechanicService
    {
        MechanicDTO GetMechanic(int id);
    }
}
