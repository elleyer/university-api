using Admin.Models.Scheduler;
using Newtonsoft.Json;

namespace Admin.Models.Requests
{
    public class AddSchedulerDayRequest
    {
        [JsonProperty("facultyName")]
        public string FacultyName { get; set; }
        
        [JsonProperty("specialityCode")]
        public int SpecialityCode { get; set; }
        
        [JsonProperty("groupName")]
        public string GroupName { get; set; }
        
        [JsonProperty("groupCode")]
        public int GroupCode { get; set; }
        
        [JsonProperty("subCode")]
        public int SubgroupCode { get; set; }

        [JsonProperty("scheduleWeekDay")] 
        public ScheduleWeekDay WeekDay { get; set; }
    }
}