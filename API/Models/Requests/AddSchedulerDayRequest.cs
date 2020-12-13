using Newtonsoft.Json;

namespace Admin.Models.Requests
{
    public class AddSchedulerDayRequest
    {
        [JsonProperty("facultyId")]
        public int FacultyId { get; set; }
        
        [JsonProperty("specialityId")]
        public int SpecialityId { get; set; }
        
        [JsonProperty("groupId")]
        public int GroupId { get; set; }
        
        [JsonProperty("subId")]
        public int SubgroupId { get; set; }

        [JsonProperty("scheduleWeekDay")] 
        public ScheduleWeekDay WeekDay { get; set; }
    }
}