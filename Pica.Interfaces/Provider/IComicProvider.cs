using System.Threading.Tasks;

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
        Task<string> SearchComic(string keyword,int pagesize = 1);

        /// <summary>
        /// 获取本子详情页面
        /// </summary>
        /// <param name="bookid"></param>
        /// <returns></returns>
        Task<string> GetComicDetail(string bookid);

        /// <summary>
        /// 获取本子分卷
        /// </summary>
        /// <param name="bookid">id</param>
        /// <param name="pagesize">本子详情数据中的PagesCount</param>
        /// <returns></returns>
        Task<string> GetComicEpisode(string bookid,int pagesize = 1);


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
