using Pica.Models.ApiModels;
using Pica.Models.ApiModels.Comics;
using Pica.Models.ApiModels.Search;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pica.Interfaces.Provider;

public interface ISearchProvider
{
    public Task<ResultCode<KeyWordsData>> SearchKeys();

    public Task<ResultCode<SearchResult>> Search(string Key,int page=1,SortType type= SortType.ua, IEnumerable<string>? categories = default);

    public Task<string> Search(string category,int page = 1,SortType type = SortType.ua);
}
