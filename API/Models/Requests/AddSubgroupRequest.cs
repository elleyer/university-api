using Newtonsoft.Json;

namespace Admin.Models.Requests
{
    public class AddSubgroupRequest
    {
        [JsonProperty("facultyName")]
        public string FacultyName { get; set; }
        
        [JsonProperty("specialityCode")]
        public int SpecialityCode { get; set; }
        
        [JsonProperty("groupName")]
        public string GroupName { get; set; }
        
        [JsonProperty("groupCode")]
        public int GroupCode { get; set; }

        [JsonProperty("code")]
        public int Code { get; set; }
    }
}