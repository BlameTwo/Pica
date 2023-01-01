using Pica.Interfaces;
using Pica.Interfaces.Provider;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace PicaApi.Services.ApiProvider
{
    /// <summary>
    /// 
    /// </summary>
    public class InitProvider:IInitProvider
    {
        public string InitUrl { get; set; } = "http://68.183.234.72/init";


        public async Task<Stream> SendAsync(HttpRequestMessage request)
        {
            HttpClient httpClient= new HttpClient();
            var requespn = await  httpClient.SendAsync(request);
            Stream stream = await requespn.Content.ReadAsStreamAsync();
            return stream;
        }
    }
}
