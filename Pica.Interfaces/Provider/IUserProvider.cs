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

        Task<ResultCode<FavouriteData>> GetUserFavourite(int pagesize = 0);
    }

}
