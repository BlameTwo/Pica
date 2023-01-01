using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.Json.Serialization;

namespace Pica.Models.ApiModels
{
    /// <summary>
    /// 分流IPData
    /// </summary>
    public class InitData
    {
        public InitData(string status, List<string> ips, string waka, string adKeyWorkd)
        {
            Status = status;
            Ips = ips;
            Waka = waka;
            AdKeyWorkd = adKeyWorkd;
        }
        [JsonPropertyName("status")]public string Status { get; set; }

        [JsonPropertyName("addresses")]public List<string> Ips { get; set; }

        [JsonPropertyName("waka")]public string Waka { get; set; }

        [JsonPropertyName("adKeyword")]public string AdKeyWorkd { get; set; }
    }

    /// <summary>
    /// 统一返回码+内容
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResultCode<T>
    {
        [JsonPropertyName("code")] public int Code { get; set; }

        public ResultCode(int code, string message, T data)
        {
            Code = code;
            Message = message;
            Data = data;
        }

        [JsonPropertyName("message")] public string Message { get; set; }

        [JsonPropertyName("data")]public T Data { get; set; }
    }

}
