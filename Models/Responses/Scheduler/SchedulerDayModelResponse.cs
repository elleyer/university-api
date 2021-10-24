using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Admin.Models.Scheduler
{
    public class SchedulerDayModelResponse
    {
        public virtual ScheduleWeekDay ScheduleWeekDay { get; set; }
        
        [ForeignKey("PairedSubjects")]
        public virtual List<SubjectModel> ClassSubjects { get; set; }
    }
}