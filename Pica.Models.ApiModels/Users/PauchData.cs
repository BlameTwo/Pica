using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Pica.Models.ApiModels.Users
{
    public class PauchData
    {
        [JsonPropertyName("res")]
        public Res Resource { get; set; } 
    }

    public class Res
    {
        /// <summary>
        /// 签到成功后返回YES，已经签过了显示fail，初次之外全是错误
        /// </summary>
        [JsonPropertyName("status")]public string Status { get; set;}

        /// <summary>
        /// 应该是最近的签到日期
        /// </summary>
        [JsonPropertyName("punchInLastDay")]public string LastDay { get; set;}
    }
}
