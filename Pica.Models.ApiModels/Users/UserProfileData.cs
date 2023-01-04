using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Pica.Models.ApiModels.Users
{

    public class UserProfileData
    {

        [JsonPropertyName("user")]public UserProfileData_User Data { get; set; }
    }

    public class UserProfileData_User
    {

        [JsonPropertyName("_id")]public string ID { get; set; }

        [JsonPropertyName("name")] public string Name { get;set; }
        [JsonPropertyName("email")]public string Email { get; set; }

        /// <summary>
        /// Sex??
        [JsonPropertyName("gender")]public string Gender { get; set; }
        /// </summary>

        [JsonPropertyName("birthday")]public string Birthday { get; set; }

        [JsonPropertyName("title")]public string SubName { get; set; }

        [JsonPropertyName("verified")]public bool Verified { get; set; }

        [JsonPropertyName("exp")]public int Exp { get; set; }

        [JsonPropertyName("level")]public int Level { get; set; }

        [JsonPropertyName("characters")]public List<string> Characters { get; set; }

        [JsonPropertyName("created_at")]public string CreatedTime { get; set; }

        [JsonPropertyName("isPunched")]public bool IsPunched { get; set; }

        /// <summary>
        /// 头像框
        /// </summary>
        [JsonPropertyName("character")]public string ImageBorder { get; set; }

        [JsonPropertyName("avatar")]public UserProfile_Avatar Avatar { get; set; }
    }

    public class UserProfile_Avatar
    {
        [JsonPropertyName("originalName")] public string OriginalName { get; set; }


        /// <summary>
        /// 不包含前缀的文件路径
        /// </summary>
        [JsonPropertyName("path")] public string UriPath { get; set; }


        /// <summary>
        /// 官方的文件服务器前缀
        /// </summary>
        [JsonPropertyName("fileserver")]public string FileServer { get; set; }
    }
}
