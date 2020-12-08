using Newtonsoft.Json;

namespace Admin.Models.User
{
    public class RegistrationModel
    {
        [JsonProperty("Username")]
        public string Username { get; set; }
        
        [JsonProperty("Password")]
        public string Password { get; set; }
    }
}