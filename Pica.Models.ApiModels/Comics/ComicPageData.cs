using Pica.Models.ApiModels.Users;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace Pica.Models.ApiModels.Comics;

public class ComicPageData
{
    [JsonPropertyName("pages")] public Comic_Page_Pages Pages { get; set; }

    [JsonPropertyName("ep")]public Comic_Page_Ep Ep { get; set; }
}

public class Comic_Page_Ep
{
    [JsonPropertyName("_id")]public string ID { get; set; }

    [JsonPropertyName("title")]public string Title { get; set; }
}

public class Comic_Page_Pages
{
    [JsonPropertyName("total")]public int Total { get; set; }

    /// <summary>
    /// 单页最大的图片数量
    /// </summary>
    [JsonPropertyName("limit")]public int Limit { get; set; }

    /// <summary>
    /// 现在的页数
    /// </summary>
    [JsonPropertyName("page")]public int NowPage { get; set; }

    /// <summary>
    /// 总页数
    /// </summary>
    [JsonPropertyName("pages")]public int PageCount { get; set; }


    [JsonPropertyName("docs"),JsonConverter(typeof(Comic_Page_D_Converter))]
    public List<Comic_Page_Document> Documents { get; set; }


}


public class Comic_Page_Document
{
    [JsonPropertyName("_id")]public string Id { get; set; }

    [JsonPropertyName("id")]public string ID { get; set; }

    [JsonPropertyName("media")]public Favourite_Thumb FileSource { get; set; }
}

public class Comic_Page_D_Converter : JsonConverter<List<Comic_Page_Document>>
{
    public override List<Comic_Page_Document>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        JsonArray job = JsonObject.Parse(ref reader).AsArray();
        var listval = new List<Comic_Page_Document>();
        foreach (var item in job)
        {
            listval.Add(item.Deserialize<Comic_Page_Document>()!);
        }
        return listval;
    }

    public override void Write(Utf8JsonWriter writer, List<Comic_Page_Document> value, JsonSerializerOptions options)
    {
        throw new NotImplementedException("错误的实现");
    }
}