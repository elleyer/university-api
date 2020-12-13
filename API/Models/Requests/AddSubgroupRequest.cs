using Newtonsoft.Json;

namespace Admin.Models.Requests
{
    public class AddSubgroupRequest
    {
        [JsonProperty("facultyId")]
        public int FacultyId { get; set; }
        
        [JsonProperty("specialityId")]
        public int SpecialityId { get; set; }
        
        [JsonProperty("groupId")]
        public int GroupId { get; set; }

        [JsonProperty("code")]
        public int Code { get; set; }
    }
}