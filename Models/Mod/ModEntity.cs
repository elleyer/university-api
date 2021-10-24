using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Admin.Models.Mod.Info;
using Newtonsoft.Json;

namespace Admin.Models.Mod
{
    public class ModEntity
    {
        [Key]
        public int Id { get; set; }
        
        public string Username { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
        
        public string Token { get; set; }

        public string Role { get; set; }
        
        public bool Approved { get; set; }
        
        [JsonIgnore]
        public virtual List<AllowedFaculties> AllowedFaculties { get; set; }
        [JsonIgnore]
        public virtual List<AllowedSpecialities> AllowedSpecialities { get; set; }
        [JsonIgnore]
        public virtual List<AllowedGroups> AllowedGroups { get; set; }
        [JsonIgnore]
        public virtual List<AllowedSubgroups> AllowedSubgroups { get; set; }
    }
}