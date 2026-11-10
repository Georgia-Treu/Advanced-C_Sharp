using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace ToDoList.Models
{
    public class TicketContext : DbContext
    {
        public TicketContext(DbContextOptions<TicketContext> options)
            : base(options) { }

        public DbSet<Ticket> Tickets { get; set; } = null!;
        public DbSet<Status> Statuses { get; set; } = null!;
       
        protected override void OnModelCreating(
        ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ConfigureStatuses());
            modelBuilder.ApplyConfiguration(new ConfigureTickets());
        }
    }

}
