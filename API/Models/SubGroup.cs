using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Admin.Models
{
    public class SubGroup
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        
        public int Code { get; set; }

        public virtual Scheduler Scheduler { get; set; }
    }
}