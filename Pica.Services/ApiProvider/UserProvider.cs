using Pica.Interfaces;
using Pica.Interfaces.Provider;
using Pica.Models.ApiModels.Users;
using Pica.Models.ApiModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net.Http;

namespace Pica.Services.ApiProvider
{
    public class UserProvider : IUserProvider
    {
        public UserProvider(IGetRequestMessage getRequestMessage,IPica3Client pica3Client)
        {
            GetRequestMessage = getRequestMessage;
            Pica3Client= pica3Client;
        }

        public IGetRequestMessage GetRequestMessage { get; }
        public IPica3Client Pica3Client { get; }

        public async Task<ResultCode<FavouriteData>> GetUserFavourite(int pagesize = 1)
        {
            var request = GetRequestMessage.GetRequestMessageAsync(HttpMethod.Get
                , uri: $"users/favourite?page={pagesize}&s=ua", null, true, null
                );
            var result = await Pica3Client._httpclient.SendAsync(request);
            return Pica.Models.PicaJsonConverts.ReadJson.Read<ResultCode<FavouriteData>>( await result.Content.ReadAsStreamAsync().ConfigureAwait(false));
        }

        public async Task<ResultCode<UserProfileData>> GetUserProfile(string id="")
        {
            string url = "";
            if (string.IsNullOrWhiteSpace(id))
            {
                url = $"users/{id}/profile";
            }
            var request = GetRequestMessage.GetRequestMessageAsync(
                HttpMethod.Get,
                url, 
                null,
                true);
            var result = await Pica3Client._httpclient.SendAsync(request).ConfigureAwait(false);
            Stream stream = await result.Content.ReadAsStreamAsync();
            return Pica.Models.PicaJsonConverts.ReadJson.Read<ResultCode<UserProfileData>>(stream);
        }

        public async Task<ResultCode<PauchData>> UserPauch()
        {
            string url = "users/punch-in";
            var request = GetRequestMessage.GetRequestMessageAsync(
                HttpMethod.Post, url, null, true);
            var result = await Pica3Client._httpclient.SendAsync(request).ConfigureAwait(false);
            var stream = await result.Content.ReadAsStreamAsync().ConfigureAwait(false);
            return Pica.Models.PicaJsonConverts.ReadJson.Read<ResultCode<PauchData>>(stream);
        }

    }
}
