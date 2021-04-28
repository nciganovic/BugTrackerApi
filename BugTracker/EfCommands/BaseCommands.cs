using DataAccess;

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
