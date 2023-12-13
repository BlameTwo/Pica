using Pica.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Pica.Services
{
    public class GetRequestMessage : IGetRequestMessage
    {
        public IApisProvider ApisProvider { get; }
        public IPicaClient PicaClient { get; }

        public GetRequestMessage(IApisProvider apisProvider, IPicaClient pica3Client)
        {
            ApisProvider = apisProvider;
            PicaClient = pica3Client;
        }

        private string GetSignature(HttpRequestMessage request)
        {
            var data =
                $"{request.RequestUri?.OriginalString}{ApisProvider.TimeStamp}{ApisProvider.Nonce}{request.Method}{ApisProvider.ApiKey}".ToLower();
            using var hmacsha256 = new HMACSHA256(ApisProvider.SignatureKey);
            byte[] hash = hmacsha256.ComputeHash(Encoding.UTF8.GetBytes(data));
            return Convert.ToHexString(hash).ToLower();
        }

        public async Task<Stream> SendAsync(HttpRequestMessage request)
        {
            var quesonse = await PicaClient._httpclient.SendAsync(request).ConfigureAwait(false);
            quesonse.EnsureSuccessStatusCode();
            var result = await quesonse.Content.ReadAsStreamAsync();
            string str = await quesonse.Content.ReadAsStringAsync();
            return result;
        }

        public HttpRequestMessage GetRequestMessageAsync(
            HttpMethod httpMethod,
            string uri,
            JsonContent poststring,
            bool istoken,
            Dictionary<string, string> parames = null
        )
        {
            HttpRequestMessage request = new HttpRequestMessage(httpMethod, uri);
            //判断是否需要进行增加token方法
            if (!string.IsNullOrWhiteSpace(PicaClient.Token) && istoken)
            {
                request.Headers.Add("authorization", PicaClient.Token);
            }
            request.Content = poststring;
            if (request.Content?.Headers.ContentType != null)
            {
                request.Content.Headers.ContentType.CharSet = "UTF-8";
            }
            request.Headers.Add("time", ApisProvider.TimeStamp);
            request.Headers.Add("signature", GetSignature(request));
            request.Headers.Add("image-quality", ((int)ApisProvider.ImageQuality).ToString());
            request.Headers.Add("api-key", ApisProvider.ApiKey);
            request.Headers.Add("accept", ApisProvider.DefaultAccept);
            request.Headers.Add("app-channel", ApisProvider.AppChannel.ToString());
            request.Headers.Add("app-version", ApisProvider.AppVersion);
            //request.Headers.Add("app-build-version", ApisProvider.AppBuildVersion);
            request.Headers.Add("nonce", ApisProvider.Nonce);
            request.Headers.Add("app-platform", ApisProvider.AppPlatform);
            request.Headers.Add("app-uuid", "defaultUuid");
            request.Headers.Add("User-Agent", ApisProvider.DefaultUA);
            request.Headers.Add("Host", "api.manhuapica.com");
            return request;
        }

        public HttpRequestMessage GetImageMessage(HttpMethod httpMethod, string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var overrideBaseAddress = PicaClient.GetIp();
            if (overrideBaseAddress != null)
            {
                var uri = new Uri(url);
                if (url.Contains("tobeimg"))
                {
                    request.RequestUri = new Uri(
                        overrideBaseAddress,
                        uri.PathAndQuery.Replace("/static/tobeimg", "")
                    );
                    request.Headers.Add("Host", "img.picacomic.com");
                }
                else if (url.Contains("tobs"))
                {
                    request.RequestUri = new Uri(
                        overrideBaseAddress,
                        uri.PathAndQuery.Replace("/tobs", "")
                    );
                    request.Headers.Add("Host", uri.Host);
                }
                else
                {
                    request.RequestUri = new Uri(overrideBaseAddress, uri.PathAndQuery);
                    request.Headers.Add("Host", uri.Host);
                }
            }
            return request;
        }

        public async Task<Stream> ImageGetAsync(HttpRequestMessage request)
        {
            var httpClientHandler = new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = (_, _, _, _) =>
                {
                    return true;
                },
                SslProtocols =
                    System.Security.Authentication.SslProtocols.Tls12
                    | System.Security.Authentication.SslProtocols.Tls11
                    | System.Security.Authentication.SslProtocols.Tls
                    | System.Security.Authentication.SslProtocols.Tls13
            };
            HttpClient httpclient = new(httpClientHandler);
            var response = await httpclient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStreamAsync();
        }
    }
}
