using ITICDE.Enums;
using System.ComponentModel.DataAnnotations;

namespace ITICDE.ViewModels
{
    public class UserViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public OrganizationType OrganizationType { get; set; }
        [Required]
        public Discipline Discipline { get; set; }
        [Required]
        public Position Position { get; set; }
    }
    
}
