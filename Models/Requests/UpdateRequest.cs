using Admin.Models.Scheduler;
using Newtonsoft.Json;

namespace Admin.Models.Requests
{
    public class UpdateRequest //TODO: By ID's.
    {
        [JsonProperty("fc")]
        public string Faculty { get; set; }
        
        [JsonProperty("group")]
        public string Group { get; set; }
        
        [JsonProperty("spec")]
        public int Speciality { get; set; }
        
        [JsonProperty("grCode")]
        public int GroupCode { get; set; }
        
        [JsonProperty("sub")]
        public int SubGroup { get; set; }
        
        [JsonProperty("schedulerDay")]
        public SchedulerDayModel SchedulerDay { get; set; }
    }
}