using System.ComponentModel.DataAnnotations;

namespace PerSpace.Application.ApiModel.User
{
    public class UserRegisterRequest
    {

        [Required(ErrorMessage = "A email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A password is required")]
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
