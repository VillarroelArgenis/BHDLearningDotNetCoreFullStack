﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketApi.Data.Interfaces
{
    public interface IBasketContext
    {
        object Redis { get; }
    }
}
