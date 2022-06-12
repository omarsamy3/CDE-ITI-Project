﻿using ITICDE.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ITICDE.Models
{
    public class File
    {
        public File()
        {
            Users = new List<User>();

        }
        #region Properties
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Path { get; set; }
        [DataType(DataType.Date)]
        public DateTime UploadDate { get; set; } = DateTime.Now;

        public string Type { get; set; }
        



        #endregion

        #region NavigationProperties


        public int UserId { get; set; }
        public User CreatorUser { get; set; }
        public List<User> Users { get; set; }


        [Required]
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public int FolderId { get; set; }
        public Folder Folder { get; set; }


        public List<View> Views { get; set; }
        #endregion
    }
}
