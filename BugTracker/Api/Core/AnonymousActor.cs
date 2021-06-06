using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Core
{
    public class AnonymousActor : IApplicationActor
    {
        public int Id => 3;

        public string Identity => "Anonymous actor";

        public IEnumerable<int> AllowedUseCases => new List<int> { 6 };
    }
}
