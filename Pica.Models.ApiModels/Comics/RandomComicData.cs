using Pica.Models.ApiModels.Users;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Pica.Models.ApiModels.Comics;

public class RandomComicData
{
    [JsonPropertyName("comics")]
    public List<Comics_Docs> ComicList { get; set; }
}
