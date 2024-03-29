﻿using Pica.Models.ApiModels;
using System.Threading.Tasks;
using Pica.Models.ApiModels.Comics;
using Pica.Models.ApiModels.Users;

namespace Pica.Interfaces.Provider
{
    public interface IComicProvider
    {
        /// <summary>
        /// 搜索本子
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        Task<ResultCode<SearchComicData>> SearchComic(string keyword,int pagesize = 1);

        /// <summary>
        /// 获取本子详情页面
        /// </summary>
        /// <param name="bookid"></param>
        /// <returns></returns>
        Task<ResultCode<ComicDetailData>> GetComicDetail(string bookid);

        /// <summary>
        /// 获取本子分卷
        /// </summary>
        /// <param name="bookid">id</param>
        /// <param name="pagesize">本子详情数据中的PagesCount</param>
        /// <returns></returns>
        Task<ResultCode<ComicEpisodeData>> GetComicEpisode(string bookid,int pagesize = 1);

        /// <summary>
        /// 获得随机本子
        /// </summary>
        /// <returns></returns>
        Task<ResultCode<RandomComicData>> GetRandomComic();


        /// <summary>
        /// 获取本子的图片
        /// </summary>
        /// <param name="bookid"></param>
        /// <param name="Episodeid"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        Task<ResultCode<ComicPageData>> GetComicPages(string bookid, string order, int page=1);
    }
}
