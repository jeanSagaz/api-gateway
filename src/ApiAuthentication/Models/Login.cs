using System.Text.Json.Serialization;

namespace ApiAuthentication.Models
{
    public class Login
    {
        [JsonPropertyName("username")]
        public string? User { get; set; }

        [JsonPropertyName("password")]
        public string? Password { get; set; }
    }
}
