using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Admin.Models
{
    public class Speciality
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        
        public int Code { get; set; }
        
        public string DescriptionUa { get; set; }

        public virtual List<Group> Groups { get; set; }

        public Speciality()
        {
        }

        public Speciality(int code, string descr)
        {
            Code = code;
            DescriptionUa = descr;
        }
    }
}