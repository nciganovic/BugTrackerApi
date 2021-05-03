using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Commands;
using Application.Exceptions;
using DataAccess;
using Domain;

namespace EfCommands
{
    public class TicketTypeCommands : BaseCommands, ITicketTypeCommands 
    {
        public TicketTypeCommands(BugTrackerContext bugTrackerContext) : base(bugTrackerContext)
        {

        }

        public void Create(TicketType ticketType)
        {
            if (IsNameAlreadyTaken(ticketType.Name))
            {
                throw new EntityAlreadyExists();
            }

            context.Add(ticketType);
            context.SaveChanges();
        }

        public TicketType Delete(int id)
        {
            TicketType item = context.TicketTypes.Find(id);

            if (item == null)
                throw new EntityNotFoundException();

            item.DeletedAt = DateTime.Now;

            context.TicketTypes.Update(item);
            context.SaveChanges();
            return item;
        }

        public IEnumerable<TicketType> Read()
        {
            return context.TicketTypes.Select(x => new TicketType
            {
                Id = x.Id,
                Name = x.Name,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt,
                DeletedAt = x.DeletedAt
            }).ToList();
        }

        public TicketType Read(int id)
        {
            return context.TicketTypes.Where(x => x.Id == id).Select(x => new TicketType
            {
                Id = x.Id,
                Name = x.Name,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt,
                DeletedAt = x.DeletedAt
            }).ToList().FirstOrDefault();
        }

        public void Update(TicketType ticketType)
        {
            TicketType item = context.TicketTypes.Find(ticketType.Id);
            context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            if (item == null)
                throw new EntityNotFoundException();

            if (IsNameAlreadyTaken(ticketType.Name))
                throw new EntityAlreadyExists();

            var tp = context.TicketTypes.Attach(ticketType);
            tp.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }

        private bool IsNameAlreadyTaken(string name)
        {
            if (context.TicketTypes.Any(x => x.Name == name))
            {
                return true;
            }

            return false;
        }
    }
}
