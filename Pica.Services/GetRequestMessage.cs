using Pica.Interfaces;
using Pica.Models.ApiModels;
using PicaApi.Services.ApiProvider;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Pica.Services
{
    public class GetRequestMessage : IGetRequestMessage
    {
        public IApisProvider ApisProvider { get; }
        public IPica3Client Pica3Client { get; }

        public GetRequestMessage(IApisProvider apisProvider,IPica3Client pica3Client)
        {
            ApisProvider = apisProvider;
            Pica3Client = pica3Client;
        }

       

        private string GetSignature(HttpRequestMessage request)
        {
            var data = $"{request.RequestUri?.OriginalString}{ApisProvider.TimeStamp}{ApisProvider.Nonce}{request.Method}{ApisProvider.ApiKey}".ToLower();
            using var hmacsha256 = new HMACSHA256(ApisProvider.SignatureKey);
            byte[] hash = hmacsha256.ComputeHash(Encoding.UTF8.GetBytes(data));
            return Convert.ToHexString(hash).ToLower();
        }

        public async Task<Stream> SendAsync(HttpRequestMessage request)
        {
            var quesonse = await  Pica3Client._httpclient.SendAsync(request).ConfigureAwait(false);
            quesonse.EnsureSuccessStatusCode();
            var result = await quesonse.Content.ReadAsStreamAsync();
            string str = await quesonse.Content.ReadAsStringAsync();
            return result;
        }


        public HttpRequestMessage GetRequestMessageAsync(HttpMethod httpMethod,
            string uri,
            JsonContent poststring,
            bool istoken,
            Dictionary<string, string> parames = null)
        {
            HttpRequestMessage request = new HttpRequestMessage(httpMethod, uri);
            //判断是否需要进行增加token方法
            if (!string.IsNullOrWhiteSpace(Pica3Client.Token) && istoken)
            {
                request.Headers.Add("authorization", Pica3Client.Token);
            }
            request.Content = poststring;
            if (request.Content?.Headers.ContentType != null)
            {
                // 惊呆了，小写不行，必须用大写
                request.Content.Headers.ContentType.CharSet = "UTF-8";
            }
            request.Headers.Add("time", ApisProvider.TimeStamp);
            request.Headers.Add("signature", GetSignature(request));
            request.Headers.Add("image-quality", ApisProvider.ImageQuality.ToString().ToLower());
            request.Headers.Add("api-key", ApisProvider.ApiKey);
            request.Headers.Add("accept", ApisProvider.DefaultAccept);
            request.Headers.Add("app-channel", ApisProvider.AppChannel.ToString());
            request.Headers.Add("app-version", ApisProvider.AppVersion);
            request.Headers.Add("app-build-version", ApisProvider.AppBuildVersion);
            request.Headers.Add("nonce", ApisProvider.Nonce);
            request.Headers.Add("app-platform", ApisProvider.AppPlatform);
            request.Headers.Add("app-uuid", ApisProvider.AppUuid);
            request.Headers.Add("User-Agent", ApisProvider.DefaultUA);
            request.Headers.Add("Host", "picaapi.picacomic.com");
            return request;
        }
    }
}
