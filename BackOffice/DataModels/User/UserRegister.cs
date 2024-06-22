using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOffice.DataModels.User
{
    public class UserCreate
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }


        public byte[] PasswordHash { get; set; } = null!;
        public byte[] PasswordSalt { get; set; } = null!;
    }
}
