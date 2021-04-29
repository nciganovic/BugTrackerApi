using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using DataAccess.Configurations;

namespace DataAccess
{
    public class BugTrackerContext : DbContext
    {
        public DbSet<TicketPriority> TicketPriorities { get; set; }
        public DbSet<ApplicationUser> ApplicaitonUsers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<CompanyApplicaitonUser> CompanyApplicaitonUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BugTracker;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ApplicationUserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new TicketPriorityConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyApplicationUserConfiguration());
        }
    }
}
