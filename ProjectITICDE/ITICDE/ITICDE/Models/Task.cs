using ITICDE.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        public Progress Progress { get; set; } = Progress.Starting;
        public Priority Priority { get; set; } = Priority.Normal;
        public string Description { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreationDate { get; set; } = DateTime.Now;
        [DataType(DataType.DateTime)]
        public DateTime DeadLine { get; set; }
        #endregion

        #region NavigationProperties
        [Required]
        public int CreatorUserId { get; set; }


        public User CreatorUser { get; set; }

        public List<User> Users { get; set; }

        [Required]
        public int ProjectId { get; set; }


        public Project Project { get; set; }


        #endregion
    }
}
