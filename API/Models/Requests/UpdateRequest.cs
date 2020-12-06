using Newtonsoft.Json;

namespace Admin.Models.Requests
{
    public class UpdateRequest
    {
        [JsonProperty("token")]
        public string Token { get; set; }
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
        public SchedulerDay SchedulerDay { get; set; }
    }
}