using System.Collections.Generic;
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

        public SubGroup()
        {
        }

        public SubGroup(int code)
        {
            Code = code;

            Scheduler = new Scheduler {SchedulerDays = new List<SchedulerDay>()};

        }
    }
}