using ITICDE.Enums;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITICDE.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            CreatedProjects=new List<Project>();
            WorkonProjects = new List<Project>();
            CreatedTeams = new List<Team>();
            JoinedTeams = new List<Team>();
            CreatedFolders = new List<Folder>();
            SharedFolders = new List<Folder>();
            UploadedFiles = new List<File>();
            SharedFiles = new List<File>();
            CreatedViews = new List<View>();
            SharedViews = new List<View>();
            CreatedTasks = new List<Task>();
            SharedTasks = new List<Task>();
        }
		#region Properties

		[Required]
        public string Name { get; set; }

        public byte[] ProfilePicture { get; set; }


        [Required]
        [Column(TypeName = "nvarchar(32)")]
        public OrganizationType OrganizationType { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(32)")]
        public Discipline Discipline { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(32)")]
        public Position Position { get; set; }

        
        #endregion


        #region NavigationProperties

        [InverseProperty("CreatorUser")]
        public List<Project> CreatedProjects { get; set; }
        [InverseProperty("Users")]
        public List<Project> WorkonProjects { get; set; }

        [InverseProperty("CreatorUser")]
        public List<Team> CreatedTeams { get; set; }
        [InverseProperty("Users")]
        public List<Team> JoinedTeams { get; set; }

        [InverseProperty("CreatorUser")]
        public List<Folder> CreatedFolders { get; set; }
        [InverseProperty("Users")]
        public List<Folder> SharedFolders { get; set; }

        [InverseProperty("CreatorUser")]
        public List<File> UploadedFiles { get; set; }
        [InverseProperty("Users")]
        public List<File> SharedFiles { get; set; }

        [InverseProperty("CreatorUser")]
        public List<View> CreatedViews { get; set; }
        [InverseProperty("Users")]
        public List<View> SharedViews { get; set; }

        [InverseProperty("CreatorUser")]
        public List<Task> CreatedTasks { get; set; }
        [InverseProperty("Users")]
        public List<Task> SharedTasks { get; set; }

        #endregion
    }
}
