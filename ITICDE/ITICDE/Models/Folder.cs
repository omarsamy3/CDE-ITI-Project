using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ITICDE.Models
{
    public class Folder
    {
        public Folder()
        {
            InnerFolders = new List<Folder>();
            Users = new List<User>();
            Files = new List<File>();
        }

        #region Properties
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; } = DateTime.Now;
		public bool HasParent { get; set; }

        public int ParentId { get; set; }
        #endregion

        #region NavigationProperties
        public List<Folder> InnerFolders { get; set; }

        [Required]
        public string UserId { get; set; }
        public User CreatorUser { get; set; }
        public List<User> Users { get; set; }
        [Required]
        public int ProjectId { get; set; }
        public Project Project { get; set; }


        public List<File> Files { get; set; }
        #endregion

    }
}
