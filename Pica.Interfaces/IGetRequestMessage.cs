using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Pica.Interfaces
{
    /// <summary>
    /// 程序集内调用，获得请求参数方法
    /// </summary>
    public interface IGetRequestMessage
    {
        /// <summary>
        /// 获得请求
        /// </summary>
        /// <param name="httpMethod">请求方式</param>
        /// <param name="uri">url地址（口误</param>
        /// <param name="parames">参数列表</param>
        /// <returns></returns>
        HttpRequestMessage GetRequestMessageAsync(
            HttpMethod httpMethod,
            string uri,
            JsonContent poststring,
            bool istoken,
            Dictionary<string, string> parames = null);

        HttpRequestMessage GetImageMessage(HttpMethod httpMethod, string url);


        Task<Stream> SendAsync(HttpRequestMessage request);

        Task<Stream> ImageGetAsync(HttpRequestMessage request);

    }
}
