using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerSpace.Application.DTOsModel.Todo
{
    public class TodoGetAllDto
    {
        public Guid Id { get; set; }
        public DateTime CreateTime { get; set; }
        public string Category { get; set; }
        public DateTime CompletedDate { get; set; }
        public bool Recurring { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsActive { get; set; }
    }
}
