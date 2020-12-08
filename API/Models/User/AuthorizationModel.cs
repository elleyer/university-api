using Newtonsoft.Json;

namespace Admin.Models.User
{
    public class LoginForm
    {
        [JsonProperty("Username")]
        public string Username { get; set; }
        
        [JsonProperty("Password")]
        public string Password { get; set; }
    }
}