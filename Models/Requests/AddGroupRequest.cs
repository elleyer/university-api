using Newtonsoft.Json;

namespace Admin.Models.Requests
{
    public class AddGroupRequest
    {
        [JsonProperty("facultyName")]
        public string FacultyName { get; set; }
        
        [JsonProperty("specialityCode")]
        public int SpecialityCode { get; set; }
        
        [JsonProperty("nameEn")]
        public string NameEn { get; set; }
        
        [JsonProperty("nameUa")]
        public string NameUa { get; set; }
        
        [JsonProperty("code")]
        public int Code { get; set; }
    }
}