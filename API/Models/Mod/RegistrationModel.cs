using Newtonsoft.Json;

namespace Admin.Models.Mod
{
    public class RegistrationModel
    {
        [JsonProperty("Username")]
        public string Username { get; set; }
        
        [JsonProperty("Password")]
        public string Password { get; set; }
    }
}