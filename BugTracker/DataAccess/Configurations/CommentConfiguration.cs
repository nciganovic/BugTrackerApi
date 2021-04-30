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
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(x => x.Text)
                .HasMaxLength(300)
                .IsRequired();

            builder.HasOne(c => c.ApplicationUser)
                .WithMany(au => au.Comments)
                .HasForeignKey(c => c.ApplicationUserId);

            builder.HasOne(c => c.Ticket)
                .WithMany(au => au.Comments)
                .HasForeignKey(c => c.TicketId);
        }
    }
}
