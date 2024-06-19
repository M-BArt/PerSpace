using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerSpace.Domain.DataModels
{
    public class TodoCompleteTask
    {
        public bool IsCompleted { get; set; }
        public DateTime CompletedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
