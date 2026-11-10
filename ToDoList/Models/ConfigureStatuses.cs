using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ToDoList.Models
{
    internal class ConfigureStatuses : IEntityTypeConfiguration<Status> 
    {
        public void Configure(EntityTypeBuilder<Status> entity) 
        {
            entity.HasData(
               new Status
               {
                   StatusId = "todo",
                   Name = "To Do"
               },

               new Status
               {
                   StatusId = "inprogress",
                   Name = "In Progress"
               },

               new Status
               {
                   StatusId = "qa",
                   Name = "Quality Assurance"
               },

               new Status
               {
                   StatusId = "done",
                   Name = "Done"
               }
             );
        }
    }
}
