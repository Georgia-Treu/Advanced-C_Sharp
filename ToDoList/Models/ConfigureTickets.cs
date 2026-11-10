using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ToDoList.Models
{
    internal class ConfigureTickets : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> entity) 
        {
            entity.HasData(

                new Ticket
                {
                    Id = 10,
                    Name = "Login Page",
                    Description = "Create login page",
                    SprintNumber = 1,
                    PointValue = 3,
                    StatusId = "todo"
                },

                new Ticket
                {
                    Id = 11,
                    Name = "Shopping",
                    Description = "Create grocery list",
                    SprintNumber = 2,
                    PointValue = 8,
                    StatusId = "inprogress"
                }
             );
        }
    }
}
