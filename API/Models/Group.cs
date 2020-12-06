using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Admin.Models
{
    public class Group
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        
        public string NameEn { get; set; }
        public string NameUa { get; set; }
        
        public int Code { get; set; }
        
        public virtual List<SubGroup> SubGroups { get; set; }
    }
}