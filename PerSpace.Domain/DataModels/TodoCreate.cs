using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerSpace.Domain.DataModels
{
    public class TodoCreate
    {
        public string Title { get; set; } = null!;
        public bool Recurring { get; set; } = false;
        public string? Description { get; set; }
        public string? Category { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
