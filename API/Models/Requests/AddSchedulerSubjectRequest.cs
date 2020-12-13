using Newtonsoft.Json;

namespace Admin.Models.Requests
{
    public class AddSchedulerSubjectRequest
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
                
        [JsonProperty("classSubject")]
        public ClassSubject ClassSubject { get; set; }
    }
}