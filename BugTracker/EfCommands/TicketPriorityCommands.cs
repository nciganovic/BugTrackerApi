using Application.Commands;
using Application.Exceptions;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCommands
{
    public class TicketPriorityCommands : BaseCommands, ITicketPriorityCommands
    {
        public TicketPriorityCommands(BugTrackerContext context) : base(context)
        {

        }

        public void Create(TicketPriority ticketPriority)
        {
            if (IsNameAlreadyTaken(ticketPriority.Name))
            {
                throw new EntityAlreadyExists();
            }

            context.Add(ticketPriority);
            context.SaveChanges();
        }

        public TicketPriority Delete(int id)
        {
            TicketPriority item = context.TicketPriorities.Find(id);
            
            if (item == null)
                throw new EntityNotFoundException();

            item.DeletedAt = DateTime.Now;

            context.TicketPriorities.Update(item);
            context.SaveChanges();
            return item;
        }

        public IEnumerable<TicketPriority> Read()
        {
            return context.TicketPriorities.Select(x => new TicketPriority
            {
                Id = x.Id,
                Name = x.Name,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt,
                DeletedAt = x.DeletedAt
            }).ToList();
        }

        public TicketPriority Read(int id)
        {
            return context.TicketPriorities.Where(x => x.Id == id).Select(x => new TicketPriority
            {
                Id = x.Id,
                Name = x.Name,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt,
                DeletedAt = x.DeletedAt
            }).ToList().FirstOrDefault();

        }

        public void Update(TicketPriority ticketPriority)
        {
            if (IsNameAlreadyTaken(ticketPriority.Name)) {
                throw new EntityAlreadyExists();
            }

            var tp = context.TicketPriorities.Attach(ticketPriority);
            tp.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }

        private bool IsNameAlreadyTaken(string name) {
            if (context.TicketPriorities.Any(x => x.Name == name)) {
                return true;
            }

            return false;
        }
    }
}
