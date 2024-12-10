using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Presentation.Models.Login
{
    public class LoginViewModel
    {
        [EmailAddress]
        public string? Email { get; set; }
        [PasswordPropertyText]
        public string? Password { get; set; }
    }
}
