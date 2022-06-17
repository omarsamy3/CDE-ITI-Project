using System.ComponentModel.DataAnnotations;

namespace ITICDE.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        
        [Display(Name = "Email")] //Delete to accept username instead of email
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }



    }
}
