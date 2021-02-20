using Newtonsoft.Json;

namespace Admin.Models.Requests
{
    public class AddFacultyRequest
    {
        [JsonProperty("nameEn")]
        public string NameEn { get; set; }
        
        [JsonProperty("nameUa")]
        public string NameUa { get; set; }
    }
}