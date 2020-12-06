using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Admin.Models
{
    public class Faculty
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        
        public string NameEn { get; set; }
        public string NameUa { get; set; }
        
        public virtual List<Speciality> Specialities { get; set; }
    }
}