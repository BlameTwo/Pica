using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Pica.Models.ApiModels.Users
{
    public class SearchComicData
    {
        [JsonPropertyName("comics")] public SearchComic_Comics SearchComic_Comics { get; set; }
    }

    public class SearchComic_Comics
    {
        [JsonPropertyName("total")] public int Total { get; set; }
        [JsonPropertyName("limit")]public int Limit { get; set; }

        /// <summary>
        /// 当前页数
        /// </summary>
        [JsonPropertyName("page")]public int Page { get; set; }
        /// <summary>
        /// 最大页数
        /// </summary>
        [JsonPropertyName("pages")]public int Pages { get; set; }

        [JsonPropertyName("docs")] public List<Comics_Docs> Docs { get; set; }
    }
}
