using System.ComponentModel.DataAnnotations;

namespace PerSpace.Application.ApiModel.Todo
{
    public class TodoCreateRequest
    {
        [Required(ErrorMessage = "A Title is required.")]
        public string Title { get; set; } = null!;
        public bool Recurring { get; set; } = false;
        public string? Description { get; set; }
        public string? Category { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
