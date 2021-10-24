using Newtonsoft.Json;

namespace Admin.Models.Requests
{
    public class AddSpecialityRequest
    {
        [JsonProperty("facultyName")] 
        public string FacultyName;
        
        [JsonProperty("code")]
        public int Code { get; set; }
        
        [JsonProperty("description")]
        public string DescriptionUa { get; set; }
    }
}