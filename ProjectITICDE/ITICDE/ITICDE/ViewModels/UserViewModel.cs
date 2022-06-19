using ITICDE.Enums;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ITICDE.ViewModels
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "You Must Enter a User Name")]
        [Display(Name = "User name")]
        [Remote("doesUserNameExist", "Account", HttpMethod = "POST",
        ErrorMessage = "User name already exists. Please enter a different user name.")]
        public string Name { get; set; }
        
        
        [Required(ErrorMessage ="You Must Enter a Passcode"), MinLength(8, ErrorMessage = "Min Length is 8 charachter"), MaxLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        
        [Required(ErrorMessage = "You Must Enter The Organization Type")]
        public OrganizationType OrganizationType { get; set; }


        [Required(ErrorMessage = "You Must Enter Your Discipline")]
        public Discipline Discipline { get; set; }

        
        [Required(ErrorMessage = "You Must Enter Your Position")]
        public Position Position { get; set; }
    }
    
}
