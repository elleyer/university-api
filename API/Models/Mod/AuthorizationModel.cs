using Newtonsoft.Json;

namespace Admin.Models.User
{
    public class AuthorizationModel
    {
        [JsonProperty("Username")]
        public string Username { get; set; }
        
        [JsonProperty("Password")]
        public string Password { get; set; }
    }
}