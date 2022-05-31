using ITICDE.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ITICDE.Models
{
    public class Template
    {
        #region Properties
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        #endregion

        #region NavigationProperties



        #endregion
    }
}
