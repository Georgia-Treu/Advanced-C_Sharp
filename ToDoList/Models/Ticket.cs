using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ToDoList.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a ticket name.")]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
        [RegularExpression("^[a-zA-Z0-9 ]+$", ErrorMessage = "Name cannot contain special characters.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a description.")]
        [StringLength(200, ErrorMessage = "Description cannot exceed 200 characters.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a sprint number.")]
        [Range(1, 100, ErrorMessage = "Sprint number must be between 1 and 100.")]
        public int? SprintNumber { get; set; }

        [Required(ErrorMessage = "Please enter a point number.")]
        [Range(1, 100, ErrorMessage = "Point value must be between 1 and 100.")]
        public int? PointValue { get; set; }        

        [Required(ErrorMessage = "Please select a status.")]
        public string StatusId { get; set; } = string.Empty;
        [ValidateNever]
        public Status Status { get; set; } = null!;       
    }
}
