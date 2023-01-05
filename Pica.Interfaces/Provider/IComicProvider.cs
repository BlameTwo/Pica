using Pica.Models.ApiModels;
using System.Threading.Tasks;
using Pica.Models.ApiModels.Comics;

namespace Pica.Interfaces.Provider
{
    public interface IComicProvider
    {
        /// <summary>
        /// 搜索漫画
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
        /// 获取本子的图片
        /// </summary>
        /// <param name="bookid"></param>
        /// <param name="Episodeid"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        Task<string> GetComicPages(string bookid, int Episodeid, int page);
    }
}
