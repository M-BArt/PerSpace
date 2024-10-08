﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerSpace.Domain.DataModels.Todo
{
    public class TodoUpdate
    {
        public string Title { get; set; }
        public bool Recurring { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public DateTime DueDate { get; set; }
    }
}
