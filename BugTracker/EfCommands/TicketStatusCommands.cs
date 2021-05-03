﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Commands;
using Application.Exceptions;
using DataAccess;
using Domain;

namespace EfCommands
{
    public class TicketStatusCommands : BaseCommands, ITicketStatusCommands
    {
        public TicketStatusCommands(BugTrackerContext context) : base(context)
        {

        }

        public void Create(TicketStatus ticketStatus)
        {
            if (IsNameAlreadyTaken(ticketStatus.Name))
            {
                throw new EntityAlreadyExists();
            }

            context.Add(ticketStatus);
            context.SaveChanges();
        }

        public TicketStatus Delete(int id)
        {
            TicketStatus item = context.TicketStatuses.Find(id);

            if (item == null)
                throw new EntityNotFoundException();

            item.DeletedAt = DateTime.Now;

            context.TicketStatuses.Update(item);
            context.SaveChanges();
            return item;
        }

        public IEnumerable<TicketStatus> Read()
        {
            return context.TicketStatuses.Select(x => new TicketStatus
            {
                Id = x.Id,
                Name = x.Name,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt,
                DeletedAt = x.DeletedAt
            }).ToList();
        }

        public TicketStatus Read(int id)
        {
            return context.TicketStatuses.Where(x => x.Id == id).Select(x => new TicketStatus
            {
                Id = x.Id,
                Name = x.Name,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt,
                DeletedAt = x.DeletedAt
            }).ToList().FirstOrDefault();
        }

        public void Update(TicketStatus ticketStatus)
        {
            TicketStatus item = context.TicketStatuses.Find(ticketStatus.Id);

            if (item == null)
                throw new EntityNotFoundException();

            context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            if (IsNameAlreadyTaken(ticketStatus.Name))
                throw new EntityAlreadyExists();

            ticketStatus.CreatedAt = item.CreatedAt;
            ticketStatus.UpdatedAt = DateTime.Now;
            ticketStatus.DeletedAt = item.DeletedAt;

            var tp = context.TicketStatuses.Attach(ticketStatus);
            tp.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }

        private bool IsNameAlreadyTaken(string name)
        {
            if (context.TicketStatuses.Any(x => x.Name == name))
            {
                return true;
            }

            return false;
        }
    }
}
