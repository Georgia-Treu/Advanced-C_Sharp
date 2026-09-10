using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace PhoneContacts.Models
{
    public class PhoneContext : DbContext
    {
        public PhoneContext(DbContextOptions<PhoneContext> options)
            : base(options)
        { }

        public DbSet<Phone> Phones { get; set; } = null!;
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Phone>().HasData(
                new Phone
                {
                    ContactId = 1,
                    Name = "Allie Johnson",
                    PhoneNumber = "515-555-1234",
                    Address = "123 Main St, Des Moines, IA",
                    Note = "Work Friend"
                },
                new Phone
                {
                    ContactId = 2,
                    Name = "Joe Smiles",
                    PhoneNumber = "515-555-4321",
                    Address = "123 Cheddar St, Grimes, IA",
                    Note = "School Friend"
                } 
             );
        }
    }
}
