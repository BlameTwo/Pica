﻿using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Pica.Models.ApiModels.Users
{
    public class FavouriteData
    {
        [JsonPropertyName("comics")]
        public Favourite_Comics Comics { get; set; }
    }

    public class PagesClass
    {

        /// <summary>
        /// 总页数
        /// </summary>
        [JsonPropertyName("pages")] public int Pages { get; set; }
        [JsonPropertyName("total")] public int Total { get; set; }


        /// <summary>
        /// 当前页数
        /// </summary>
        [JsonPropertyName("page")] public int Page { get; set; }

        /// <summary>
        /// 当前页总计
        /// </summary>
        [JsonPropertyName("limit")] public int Limit { get; set; }
    }

    public class Favourite_Comics: PagesClass
    {

        [JsonPropertyName("docs")]public List<Comics_Docs> Docs { get; set; }

    }

    public class Comics_Docs
    {
        [JsonPropertyName("_id")]public string ID { get; set; }
        [JsonPropertyName("title")]public string Title { get; set; }
        [JsonPropertyName("author")]public string SubTitle { get; set; }

        [JsonPropertyName("totalViews")]public int TotalViews { get; set; }

        [JsonPropertyName("pagesCount")]public int PagesCount { get; set; }

        [JsonPropertyName("espCount")]public int EspCount { get; set; }

        [JsonPropertyName("finished")]public bool Finished { get; set; }

        [JsonPropertyName("likesCount")]public int LiekCount { get; set; }

        [JsonPropertyName("categories")]public List<string> Categories { get; set; }

        [JsonPropertyName("thumb")]public Favourite_Thumb Thumb { get; set; }
    }

    public class Favourite_Thumb: IComicImageSource
    {
        [JsonPropertyName("originalName")]public string OriginalName { get; set; }

        [JsonPropertyName("path")]public string Path { get; set; }

        [JsonPropertyName("fileServer")]public string FileServer { get; set; }

        //这里的Url是继承，原意是让接口提供统一的下载转换方法。

        [JsonInclude]
        public string Url => FileServer.Contains("static") ? FileServer + Path : $"{FileServer}/static/{Path}";
    }
}
