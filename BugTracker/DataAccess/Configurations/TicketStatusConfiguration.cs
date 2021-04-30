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
    public class TicketStatusConfiguration : IEntityTypeConfiguration<TicketStatus>
    {
        public void Configure(EntityTypeBuilder<TicketStatus> builder)
        {
            builder.Property(ts => ts.Name)
                .HasMaxLength(30)
                .IsRequired();

            builder.HasIndex(ts => ts.Name).IsUnique();

            builder.Property(ts => ts.CreatedAt).HasDefaultValueSql("GETDATE()");
        }
    }
}
