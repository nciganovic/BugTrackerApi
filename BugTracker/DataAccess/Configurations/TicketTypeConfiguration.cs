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
    public class TicketTypeConfiguration : IEntityTypeConfiguration<TicketType>
    {
        public void Configure(EntityTypeBuilder<TicketType> builder)
        {
            builder.Property(tt => tt.Name)
                .HasMaxLength(30)
                .IsRequired();

            builder.HasIndex(tt => tt.Name).IsUnique();

            builder.Property(tt => tt.CreatedAt).HasDefaultValueSql("GETDATE()");
        }
    }
}
