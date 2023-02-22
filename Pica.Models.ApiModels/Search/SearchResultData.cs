using Pica.Models.ApiModels.Comics;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Pica.Models.ApiModels.Search;

public class SearchResult
{
    [JsonPropertyName("comics")]public SearchResultData Comics { get; set; }
}

public class SearchResultData
{
    [JsonPropertyName("total")] public int Total { get; set; }
    [JsonPropertyName("page")] public int Page { get; set; }

    [JsonPropertyName("pages")]public int Pages { get; set; }

    [JsonPropertyName("limit")]public int Limit { get; set; }

    [JsonPropertyName("docs")] public List<ComicDetail> Comics { get; set; }
}
