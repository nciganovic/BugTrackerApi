using DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Implementation.EfCommands
{
    public abstract class BaseUseCase
    {
        protected BugTrackerContext context { get; }

        protected BaseUseCase(BugTrackerContext context)
        {
            this.context = context;
        }
    }
}
