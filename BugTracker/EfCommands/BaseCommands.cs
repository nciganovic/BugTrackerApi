using DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EfCommands
{
    public abstract class BaseCommands
    {
        protected BugTrackerContext context { get; }

        protected BaseCommands(BugTrackerContext context)
        {
            this.context = context;
        }
    }
}
