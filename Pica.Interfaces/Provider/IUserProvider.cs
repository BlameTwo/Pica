using Pica.Models.ApiModels;
using Pica.Models.ApiModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pica.Interfaces.Provider
{
    public interface IUserProvider
    {
        /// <summary>
        /// 获得个人账户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ResultCode<UserProfileData>> GetUserProfile(string id = "");

        /// <summary>
        /// 哔咔签到
        /// </summary>
        /// <returns></returns>
        Task<ResultCode<PauchData>> UserPauch();


        /// <summary>
        /// 获得个人收藏
        /// </summary>
        /// <param name="sort">排序规则</param>
        /// <param name="pagesize">页数，>1</param>
        /// <returns></returns>
        Task<ResultCode<FavouriteData>> GetUserFavourite(Sort sort = Sort.ua, int pagesize = 1);
    }

}
