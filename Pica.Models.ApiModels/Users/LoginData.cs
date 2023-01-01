using System.Text.Json.Serialization;

namespace Pica.Models.ApiModels.Users
{
    public class LoginData
    {
        public LoginData(string token)
        {
            Token = token;
        }

        [JsonPropertyName("token")]public string Token { get; set; }
    }
}
