using Pica.Interfaces.Provider;
using PicaApi.Services.ApiProvider;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Pica.Models.ApiModels;
using Pica.Models.PicaJsonConverts;
using Pica.Interfaces;
using System;
using System.Net;
using System.Diagnostics;
using System.Text.Json;
using System.Net.Http.Json;
using System.Text.Json.Nodes;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Security.Principal;
using Pica.Models.ApiModels.Users;
using Pica.Services.ApiProvider;

namespace PicaApi.Services.Client
{
    public class Pica3Client:IPica3Client
    {


        #region Private Property

        private const string InitUrl = "http://68.183.234.72/init";

        private const string BaseUrl = "https://picaapi.picacomic.com/";

        private Uri? BaseAddress;

        private IWebProxy? proxy;




        #endregion



        /// <summary>
        /// 已登录
        /// </summary>
        public bool IsLogin => !string.IsNullOrWhiteSpace(Token);

        public Pica3Client(IApisProvider apisProvider)
        {
            ApisProvider = apisProvider;
        }

        public HttpClient _httpclient { get; set; }
        public ImageQuality imageQuality { get; set; } = ImageQuality.Original;
        public IApisProvider ApisProvider { get; }
        public string Token { get; set; }

        /// <summary>
        /// 更改代理和分流，参数为 null 时重置相应设置
        /// </summary>
        /// <param name="proxy">HTTP 代理</param>
        /// <param name="address">分流 IP，通过 <see cref="GetIpListAsync"/> 获取，参数模板 new Uri("https://0.0.0.0")，http 也可以</param>
        public void ChangeProxyAndBaseAddress(IWebProxy? proxy = null, Uri? address = null)
        {
            this.proxy = proxy;
            BaseAddress = address;
            CreateHttpClient();
        }


        private void CreateHttpClient()
        {
            _httpclient = new HttpClient(new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.All,
                Proxy = proxy,
                ServerCertificateCustomValidationCallback = (_, _, _, _) => true
            });
            _httpclient.BaseAddress = BaseAddress ?? new Uri(BaseUrl);
            _httpclient.Timeout = TimeSpan.FromSeconds(10);
        }




        public async Task<InitData> GetIpList()
        {
            var resunt = await _httpclient.GetAsync(InitUrl);
            resunt.EnsureSuccessStatusCode();
            return Pica.Models.PicaJsonConverts.ReadJson.Read<InitData>(await resunt.Content.ReadAsStreamAsync());
        }

        public void SetIp(IWebProxy proxy,string proxystring)
        {
            ChangeProxyAndBaseAddress(proxy,new Uri($"https://{proxystring}"));
        }


        public void InitClient()
        {
            if (_httpclient == null)
            {
                _httpclient = new HttpClient(new HttpClientHandler
                {
                    AutomaticDecompression = DecompressionMethods.All,
                    Proxy = proxy,
                    ServerCertificateCustomValidationCallback = (_, _, _, _) => true
                });
                _httpclient.Timeout = TimeSpan.FromSeconds(10);
            }
        }
    }
}
