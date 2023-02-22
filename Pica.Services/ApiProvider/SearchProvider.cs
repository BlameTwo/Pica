using Pica.Interfaces;
using Pica.Interfaces.Provider;
using Pica.Models.ApiModels;
using Pica.Models.ApiModels.Comics;
using Pica.Models.ApiModels.Search;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Pica.Services.ApiProvider;

public class SearchProvider : ProviderBase,ISearchProvider
{
    public SearchProvider(IPica3Client pica3Client, IGetRequestMessage getRequestMessage) 
        :base(pica3Client:pica3Client,getRequestMessage:getRequestMessage)
    {

    }


    public async Task<ResultCode<SearchResult>> Search(string Key, int page = 1, SortType type = SortType.ua, IEnumerable<string>? categories = null)
    {
        return await Task.Run(async () =>
        {
            var jsoncontent = JsonContent.Create(new { Key,sort=type.ToString(),categories});
            var request = GetRequestMessage.GetRequestMessageAsync(HttpMethod.Post, $"comics/advanced-search?page={page}",jsoncontent,true,null);
            var result = await Pica3Client._httpclient.SendAsync(request);
            result.EnsureSuccessStatusCode();
            
            var stream =  await result.Content.ReadAsStreamAsync().ConfigureAwait(false);

            return Pica.Models.PicaJsonConverts.ReadJson.Read<ResultCode<SearchResult>>(stream);
        });
    }

    public Task<string> Search(string category, int page = 1, SortType type = SortType.ua)
    {
        throw new System.NotImplementedException();
    }


    public async Task<ResultCode<KeyWordsData>> SearchKeys()
    {
        return await Task.Run(async () =>
        {
            var request = GetRequestMessage.GetRequestMessageAsync(HttpMethod.Get, "keywords", null, true, null);
            var result = await Pica3Client._httpclient.SendAsync(request);
            result.EnsureSuccessStatusCode();
            Stream str = await result.Content.ReadAsStreamAsync().ConfigureAwait(false);
            return Pica.Models.PicaJsonConverts.ReadJson.Read<ResultCode<KeyWordsData>>(str);
        });
    }
}
