using Newtonsoft.Json;

namespace Admin.Models.Requests
{
    public class AddGroupRequest
    {
        [JsonProperty("facultyId")]
        public int FacultyId { get; set; }
        
        [JsonProperty("specialityId")]
        public int SpecialityId { get; set; }
        
        [JsonProperty("nameEn")]
        public string NameEn { get; set; }
        
        [JsonProperty("nameUa")]
        public string NameUa { get; set; }
        
        [JsonProperty("code")]
        public int Code { get; set; }
    }
}