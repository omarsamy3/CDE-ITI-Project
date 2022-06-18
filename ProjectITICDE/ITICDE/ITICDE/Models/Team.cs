using ITICDE.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ITICDE.Models
{
    public class Team
    {
        public Team()
        {
            Users = new List<User>();
        }
        #region Properties
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime LastAccess { get; set; } = DateTime.Now;
        #endregion

        #region NavigationProperties

        public string CreatorUserId { get; set; }
        
        [Display(Name = "Employer")]
        public User CreatorUser { get; set; }
        public List<User> Users { get; set; }

        [Required]
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        #endregion
    }
}
