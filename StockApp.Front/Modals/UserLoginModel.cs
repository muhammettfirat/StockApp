using System.ComponentModel.DataAnnotations;

namespace StockApp.Front.Modals
{
    public class UserLoginModel
    {
        [Required(ErrorMessage = "Username required")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Password required")]
        public string? Password { get; set; } 
        public bool RememberMe { get; set; } 
    }
}
