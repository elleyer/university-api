using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Admin.Models.Scheduler;
using Newtonsoft.Json;

namespace Admin.Models
{
    public class SubGroup
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }

        public int Code { get; set; }

        public virtual SchedulerModel Scheduler { get; set; }

        public SubGroup()
        {
        }

        public SubGroup(int code)
        {
            Code = code;

            Scheduler = new SchedulerModel {SchedulerDays = new List<SchedulerDayModel>()};
        }
    }
}