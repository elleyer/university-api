using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Admin.Models.Scheduler
{
    public class SchedulerModelResponse
    {
        [ForeignKey("SchedulerDays")]
        public virtual List<SchedulerDayModel> SchedulerDays { get; set; }
    }
}