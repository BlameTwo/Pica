using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Pica.Models.ApiModels.Search;

public class KeyWordsData
{
    [JsonPropertyName("keywords")]public List<string> KeyWords { get; set; }
}
