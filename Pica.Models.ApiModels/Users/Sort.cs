using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pica.Models.ApiModels.Users
{
    //此类型来自于：https://github.com/Scighost/Pica3/blob/41c706f8fbb001b9dc096e1e4d01b9727359ee98/Pica3.CoreApi/Comic/SortType.cs
    public enum Sort
    {
        /// <summary>
        /// 默认
        /// </summary>
        ua,

        /// <summary>
        ///  新到旧
        /// </summary>
        dd,

        /// <summary>
        /// 旧到新
        /// </summary>
        da,

        /// <summary>
        /// 爱心最多
        /// </summary>
        ld,

        /// <summary>
        /// 绅士指数最多
        /// </summary>
        vd
    }
}
