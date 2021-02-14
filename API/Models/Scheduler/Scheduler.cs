using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Admin.Models
{
    public class Scheduler
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }

        [ForeignKey("SchedulerDays")]
        public virtual List<SchedulerDay> SchedulerDays { get; set; }
    }

    public class SchedulerDay
    {
        [Key]
        public int Id { get; set; }
        
        public virtual ScheduleWeekDay ScheduleWeekDay { get; set; }
        
        [ForeignKey("PairedSubjects")]
        public virtual List<ClassSubject> ClassSubjects { get; set; }
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
        None = 0,
        Physical = 1 << 0,
        Remote = 1 << 1
    }

    public enum LessonContext
    {
        None = 0,
        Lecture = 1 << 0,
        PracticalWork = 1 << 1,
        LaboratoryWork = 1 << 2
    }
}