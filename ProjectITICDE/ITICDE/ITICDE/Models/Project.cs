using ITICDE.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITICDE.Models
{
    public class Project
    {

        public Project()
        {
            Users = new List<User>();
            Views = new List<View>();
            Files = new List<File>();
            Folders = new List<Folder>();
            Teams = new List<Team>();
            Tasks = new List<Task>();
        }
        #region Properties
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(32)")]
        public Units Units { get; set; } = Units.Metric;

        public Progress Progress { get; set; } = Progress.Starting;
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; } = DateTime.Now;
        [Required]
        public string Description { get; set; }
        #endregion



        #region NavigationProperties

        public int CreatorUserId { get; set; }
     
        public User CreatorUser { get; set; }

        public List<User> Users { get; set; }

        public List<View> Views { get; set; }

        public List<Folder> Folders { get; set; }

        public List<File> Files { get; set; }

        public List<Team> Teams { get; set; }

        public List<Task> Tasks { get; set; }

        #endregion

    }
}
