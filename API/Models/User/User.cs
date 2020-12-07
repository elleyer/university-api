using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Admin.Models.User.Info;

namespace Admin.Models.User
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        
        public string Username { get; set; }

        public string Salt { get; set; }

        public UserType UserType { get; set; }
        
        public bool Approved { get; set; }
        
        public virtual List<AllowedFaculties> AllowedFaculties { get; set; }
        public virtual List<AllowedSpecialities> AllowedSpecialities { get; set; }
        public virtual List<AllowedGroups> AllowedGroups { get; set; }
        public virtual List<AllowedSubgroups> AllowedSubgroups { get; set; }
    }

    [Flags]
    public enum UserType
    {
        Administrator = 0,
        Moderator = 1 << 0,
        ReadOnly = 1 << 1
    }
}