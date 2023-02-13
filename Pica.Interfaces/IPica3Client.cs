using Pica.Models.ApiModels;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Pica.Interfaces
{
    public interface IPica3Client
    {
        /// <summary>
        /// 获得分流IP
        /// </summary>
        /// <returns></returns>
        public Task<InitData> GetIpList();

        HttpClient _httpclient { get; set; }

        /// <summary>
        /// 设置代理和分流IP
        /// </summary>
        /// <param name="proxy"></param>
        /// <param name="proxystring"></param>
        public void SetIp(IWebProxy proxy, string proxystring);

        /// <summary>
        /// 初始化无token客户端
        /// </summary>
        void InitClient();

        ImageQuality imageQuality { get; set; }

        public bool IsLogin();

        string Token { get; set; }
    }
}
