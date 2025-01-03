using System.Text.Json.Serialization;

namespace ApiAuthentication.Models
{
    public class AuthToken
    {
        [JsonPropertyName("access_token")]
        public string? Token { get; set; }

        [JsonPropertyName("expiresIn")]
        public int? ExpiresIn { get; set; }
    }
}
