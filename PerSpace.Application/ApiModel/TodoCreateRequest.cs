﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerSpace.Application.ApiModel
{
    public class TodoCreateRequest
    {
        [Required(ErrorMessage = "Tytuł dla zadania jest wymagany.")]
        public string Title { get; set; } = null!;
        public bool Recurring { get; set; } = false;
        public string? Description { get; set; }
        public string? Category { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
