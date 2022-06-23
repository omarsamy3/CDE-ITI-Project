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
        [Display(Name ="Team Name")]
        public string Name { get; set; }
        //[DataType(DataType.DateTime)]
        //public DateTime LastAccess { get; set; } = DateTime.Now;

		#endregion
		#region NavigationProperties

		public string CreatorUserId { get; set; }
        [Display(Name = "Creator User")]
        public User CreatorUser { get; set; }

        [Display(Name ="Team Leader")]
		public string TeamLeaderId { get; set; }
        public User TeamLeader { get; set; }
        public List<User> Users { get; set; }


        [Required]
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        #endregion
    }
}
