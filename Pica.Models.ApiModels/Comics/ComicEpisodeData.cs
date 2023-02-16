using Pica.Models.ApiModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Pica.Models.ApiModels.Comics;
public class ComicEpisodeData
{
    [JsonPropertyName("eps")] public ComicEp_Eps ComicEp_Eps { get; set; }
}


public class ComicEp_Eps : PagesClass
{
    [JsonPropertyName("docs")]
    [JsonConverter(typeof(EpsConverter))]
    public List<Eps_Docs> Eps_Docs { get; set; }
}

public class EpsConverter : JsonConverter<List<Eps_Docs>>
{
    public override List<Eps_Docs>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        //分卷为数组类型，这里因为原字符串为数字属性，不好使用自动反序列化，在中间加入一个Convert转换器进行转换。
        JsonArray job = JsonObject.Parse(ref reader).AsArray();
        List<Eps_Docs> list = new();
        foreach (var item in job)
        {
            list.Add(item.Deserialize<Eps_Docs>()!);
        }
        return list;
    }

    public override void Write(Utf8JsonWriter writer, List<Eps_Docs> value, JsonSerializerOptions options)
    {
        throw new Exception("当前版本API不应该在此使用Write方法！！！");
    }
}

public class Eps_Docs
{
    [JsonPropertyName("_id")]public string _ID { get; set; }

    [JsonPropertyName("title")]public string Title { get; set; }

    [JsonPropertyName("order")]public int Order { get; set; }

    [JsonPropertyName("updated_at")]public DateTime UpDataAt { get; set; }

    [JsonPropertyName("id")]public string ID { get; set; }
}

