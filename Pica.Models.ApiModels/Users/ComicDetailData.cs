using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Pica.Models.ApiModels.Users
{
    public class ComicDetailData
    {
        [JsonPropertyName("comic")]public ComicDetail ComicDetail  { get; set;   }
    }

    public class ComicDetail: Comics_Docs
    {
        [JsonPropertyName("_creator")]public ComicDetail_Creator ComicDetail_Creator { get; set; }

        [JsonPropertyName("description")]public string Description { get; set; }

        [JsonPropertyName("chineseTeam")]public string TeamDisplayName { get; set; }

        [JsonPropertyName("tags")]public List<string> Tags { get; set; }

        /// <summary>
        /// 总卷数
        /// </summary>

        [JsonPropertyName("epsCount")]public int EpsCount { get; set; }

        [JsonPropertyName("updated_at")]public DateTime? UpdatedAt { get; set; }

        [JsonPropertyName("created_at")]public string CreatedAt { get; set; }

        /// <summary>
        /// 是否允许下载？
        /// </summary>
        [JsonPropertyName("allowDownload")]public bool AllowDownload { get; set; }

        /// <summary>
        /// 是否允许评论？
        /// </summary>
        [JsonPropertyName("allowComment")]public bool AllowComment { get; set; }

        [JsonPropertyName("totalLikes")]public int TotalLikes { get; set; }
        
        
        [JsonPropertyName("totalViews")]public int TotalViews { get; set; }
        
        [JsonPropertyName("totalComments")]public int TotalComment { get; set; }

        [JsonPropertyName("viewCount")]public int ViewCount { get; set; }


        [JsonPropertyName("commentsCount")]public int CommentsCount { get; set; }

        /// <summary>
        /// 是否收藏
        /// </summary>
        [JsonPropertyName("isFavourite")]public bool IsFav { get; set; }

        /// <summary>
        /// 是否喜欢
        /// </summary>

        [JsonPropertyName("isLiked")]public bool IsLike { get; set; }
    }

    public class ComicDetail_Creator: UserProfileData_User
    {
        [JsonPropertyName("slogan")]public string ComicDetail_Id { get; set; }
    }
}
