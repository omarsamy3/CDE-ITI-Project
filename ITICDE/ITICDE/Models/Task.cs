using ITICDE.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITICDE.Models
{
    public class Task
    {

        public Task()
        {
            Users = new List<User>();
        }
        #region Properties
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Column(TypeName = "nvarchar(32)")]
        public Progress Progress { get; set; } = Progress.Starting;
        [Column(TypeName = "nvarchar(32)")]
        public Priority Priority { get; set; } = Priority.Normal;
        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; } = DateTime.Now;
        [DataType(DataType.Date)]
        public DateTime DeadLine { get; set; }
        #endregion

        #region NavigationProperties
        [Required]
        public string CreatorUserId { get; set; }


        public User CreatorUser { get; set; }

        public List<User> Users { get; set; }

        [Required]
        public int ProjectId { get; set; }


        public Project Project { get; set; }


        #endregion
    }
}
