using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Configurations
{
    public class AttachmentConfiguration : IEntityTypeConfiguration<Attachment>
    {
        public void Configure(EntityTypeBuilder<Attachment> builder)
        {
            builder.Property(x => x.Path).IsRequired();
            
            builder.Property(x => x.Name).IsRequired()
                .HasMaxLength(30);

            builder.HasOne(x => x.Ticket)
                .WithMany(t => t.Attachments)
                .HasForeignKey(x => x.TicketId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
