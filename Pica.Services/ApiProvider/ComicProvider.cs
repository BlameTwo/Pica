using Pica.Interfaces;
using Pica.Interfaces.Provider;
using System.Net.Http;
using System.Threading.Tasks;

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

        public async Task<string> GetComicDetail(string bookid)
        {
            string url = $"comics/{bookid}";
            var quest = GetRequestMessage.GetRequestMessageAsync(HttpMethod.Get, url, null, true);
            var resultstream = await Pica3Client._httpclient.SendAsync(quest).ConfigureAwait(false);
            string json = await resultstream.Content.ReadAsStringAsync().ConfigureAwait(false);
            return json;
        }

        public async Task<string> GetComicEpisode(string bookid, int pagesize = 1)
        {
            string url = $"comics/{bookid}/eps?page={pagesize}";
            var quest = GetRequestMessage.GetRequestMessageAsync(HttpMethod.Get, url, null, true);
            var resultstream = await Pica3Client._httpclient.SendAsync(quest).ConfigureAwait(false);
            string json = await resultstream.Content.ReadAsStringAsync().ConfigureAwait(false);
            return json;
        }

        public Task<string> GetComicPages(string bookid, int Episodeid, int page)
        {
            throw new System.NotImplementedException();
        }

        public async Task<string> SearchComic(string keyword, int pagesize = 1)
        {
            string url = $"comics/search?page={pagesize}&q={keyword}";
            var quest = GetRequestMessage.GetRequestMessageAsync(HttpMethod.Get
                ,url,null,true,null);   
            var resultstream = await Pica3Client._httpclient.SendAsync(quest).ConfigureAwait(false);
            string str = await resultstream.Content.ReadAsStringAsync().ConfigureAwait(false);
            return str;
        }
    }
}
