﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Helpers.Domain
{
    public interface IAggregateRoot
    {
        Guid Id { get; }
    }
}
