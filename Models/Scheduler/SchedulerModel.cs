using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Admin.Models.Scheduler
{
    public class SchedulerModel
    {   
        [Key]
        [JsonIgnore]
        public int Id { get; set; }

        [ForeignKey("SchedulerDays")]
        public virtual List<SchedulerDayModel> SchedulerDays { get; set; }
    }

    public enum ScheduleWeekDay
    {
        Monday = 0,
        Tuesday = 1,
        Wednesday = 2,
        Thursday = 3,
        Friday = 4,
        Saturday = 5,
        Sunday = 6
    }

    public enum LessonType
    {
        Physical = 0,
        Remote = 1
    }

    public enum LessonContext
    {
        Lecture = 0,
        PracticalWork = 1,
        LaboratoryWork = 2
    }
}