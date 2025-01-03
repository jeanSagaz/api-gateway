namespace ApiAuthentication.Models
{
    public class User
    {
        public string? UserName { get; set; }

        public string? Password { get; set; }

        public string Role { get; set; } = string.Empty;

        public List<string> Scopes { get; set; } = new List<string>();
    }
}
