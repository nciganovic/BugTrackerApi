using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.Property(x => x.Title)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x => x.Status)
                .IsRequired()
                .HasConversion<int>();

            builder.Property(x => x.Priority)
                .IsRequired()
                .HasConversion<int>();

            builder.Property(x => x.Type)
                .IsRequired()
                .HasConversion<int>();

            builder.HasOne(t => t.OriginalTicket)
                .WithMany(th => th.TicketHistories)
                .HasForeignKey(t => t.OriginalTicketId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(t => t.Project)
                .WithMany(p => p.Tickets)
                .OnDelete(DeleteBehavior.Cascade);

          /*  builder.HasOne(t => t.TicketType)
                .WithMany(tt => tt.Tickets)
                .HasForeignKey(t => t.TicketTypeId);

            builder.HasOne(t => t.TicketStatus)
                .WithMany(ts => ts.Tickets)
                .HasForeignKey(t => t.TicketStatusId);

            builder.HasOne(t => t.TicketPriority)
                .WithMany(tp => tp.Tickets)
                .HasForeignKey(t => t.TicketPriorityId); */

            builder.HasOne(t => t.Issuer)
                .WithMany(au => au.IssuerTickets)
                .HasForeignKey(t => t.IssuerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(t => t.Developer)
                .WithMany(au => au.DeveloperTickets)
                .HasForeignKey(t => t.DeveloperId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
