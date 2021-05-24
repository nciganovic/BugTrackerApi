﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IApplicationActor
    {
        int Id { get; }
        string Identity { get; }
        IEnumerable<int> AllowedUseCases { get; }
    }
}
