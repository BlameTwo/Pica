using Pica.Interfaces;
using Pica.Interfaces.Provider;
using Pica.Models.ApiModels;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;
using Pica.Models.ApiModels.Comics;
using Pica.Models.ApiModels.Users;

namespace Pica.Services.ApiProvider
{
    public class ComicProvider : IComicProvider
    {
        public ComicProvider(IGetRequestMessage getRequestMessage,IPica3Client pica3Client)
        {
            GetRequestMessage = getRequestMessage;
            Pica3Client = pica3Client;
        }

        public IGetRequestMessage GetRequestMessage { get; }
        public IPica3Client Pica3Client { get; }

        public async Task<ResultCode<ComicDetailData>> GetComicDetail(string bookid)
        {
            string url = $"comics/{bookid}";
            var quest = GetRequestMessage.GetRequestMessageAsync(HttpMethod.Get, url, null, true);
            var resultstream = await Pica3Client._httpclient.SendAsync(quest).ConfigureAwait(false);
            Stream stream = await resultstream.Content.ReadAsStreamAsync().ConfigureAwait(false);
            return Models.PicaJsonConverts.ReadJson.Read<ResultCode<ComicDetailData>>(stream);
        }

        public async Task<ResultCode<ComicEpisodeData>> GetComicEpisode(string bookid, int pagesize = 1)
        {
            string url = $"comics/{bookid}/eps?page={pagesize}";
            var quest = GetRequestMessage.GetRequestMessageAsync(HttpMethod.Get, url, null, true);
            var resultstream = await Pica3Client._httpclient.SendAsync(quest).ConfigureAwait(false);
            string json = await resultstream.Content.ReadAsStringAsync().ConfigureAwait(false);
            Stream stream = await resultstream.Content.ReadAsStreamAsync().ConfigureAwait(false);
            return Models.PicaJsonConverts.ReadJson.Read<ResultCode<ComicEpisodeData>>(stream);
        }


        public async Task<ResultCode<RandomComicData>> GetRandomComic()
        {
            string url = $"comics/random";
            var quest = GetRequestMessage.GetRequestMessageAsync(HttpMethod.Get
                , url, null, true, null);

            var result = await Pica3Client._httpclient.SendAsync(quest).ConfigureAwait(false); ;
            Stream stream = await result.Content.ReadAsStreamAsync().ConfigureAwait(false);
            return Pica.Models.PicaJsonConverts.ReadJson.Read<ResultCode<RandomComicData>>(stream);
        }

        public async Task<ResultCode<SearchComicData>> SearchComic(string keyword, int pagesize = 1)
        {
            string url = $"comics/search?page={pagesize}&q={keyword}";
            var quest = GetRequestMessage.GetRequestMessageAsync(HttpMethod.Get
                ,url,null,true,null);   
            var resultstream = await Pica3Client._httpclient.SendAsync(quest).ConfigureAwait(false);
            Stream stream= await resultstream.Content.ReadAsStreamAsync().ConfigureAwait(false);
            return Pica.Models.PicaJsonConverts.ReadJson.Read<ResultCode<SearchComicData>>(stream);
        }

        public async Task<ResultCode<ComicPageData>> GetComicPages(string bookid, string order, int page)
        {
            string url = $"comics/{bookid}/order/{order}/pages?page={page}";
            var quest = GetRequestMessage.GetRequestMessageAsync(HttpMethod.Get, url, null, true);
            var resultstream = await Pica3Client._httpclient.SendAsync(quest).ConfigureAwait(false);
            var stream =  await resultstream.Content.ReadAsStreamAsync();
            return Pica.Models.PicaJsonConverts.ReadJson.Read<ResultCode<ComicPageData>>(stream);
        }
    }
}
