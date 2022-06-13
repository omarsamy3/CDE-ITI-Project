using ITICDE.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ITICDE.Models
{
    public class View
    {
        #region Properties
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
        [Required]
        public ViewType Type { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreationDate { get; set; } = DateTime.Now;

        #endregion

        #region NavigationProperties
        [Required]
        public int UserId { get; set; }
        public User CreatorUser { get; set; }
        public List<User> Users { get; set; }

        [Required]
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public List <File> Files { get; set; }

        #endregion
    }
}
