using Pica.Interfaces;
using Pica.Interfaces.Provider;
using Pica.Models.ApiModels.Users;
using Pica.Models.ApiModels;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;

namespace Pica.Services.ApiProvider
{
    public class UserProvider : IUserProvider
    {
        public UserProvider(IGetRequestMessage getRequestMessage,IPicaClient pica3Client)
        {
            GetRequestMessage = getRequestMessage;
            PicaClient= pica3Client;
        }

        public IGetRequestMessage GetRequestMessage { get; }
        public IPicaClient PicaClient { get; }

        public async Task<ResultCode<FavouriteData>> GetUserFavourite(Sort sort = Sort.ua,int pagesize = 1)
        {
            var request = GetRequestMessage.GetRequestMessageAsync(HttpMethod.Get
                , uri: $"users/favourite?page={pagesize}&s={sort}", null, true, null
                );
            var result = await PicaClient._httpclient.SendAsync(request);
            return Pica.Models.PicaJsonConverts.ReadJson.Read<ResultCode<FavouriteData>>( await result.Content.ReadAsStreamAsync().ConfigureAwait(false));
        }

        public async Task<ResultCode<UserProfileData>> GetUserProfile(string id="")
        {
            string url = $"users/profile";
            if (!string.IsNullOrWhiteSpace(id))
            {
                url = $"users/{id}/profile";
            }
            var request = GetRequestMessage.GetRequestMessageAsync(
                HttpMethod.Get,
                url, 
                null,
                true);
            var result = await PicaClient._httpclient.SendAsync(request).ConfigureAwait(false);
            var str = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
            Stream stream = await result.Content.ReadAsStreamAsync();
            return Pica.Models.PicaJsonConverts.ReadJson.Read<ResultCode<UserProfileData>>(stream);
        }

        public async Task<ResultCode<PauchData>> UserPauch()
        {
            string url = "users/punch-in";
            var request = GetRequestMessage.GetRequestMessageAsync(
                HttpMethod.Post, url, null, true);
            var result = await PicaClient._httpclient.SendAsync(request).ConfigureAwait(false);
            var stream = await result.Content.ReadAsStreamAsync().ConfigureAwait(false);
            return Pica.Models.PicaJsonConverts.ReadJson.Read<ResultCode<PauchData>>(stream);
        }

    }
}
