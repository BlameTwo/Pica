using Pica.Interfaces;
using Pica.Interfaces.Provider;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Pica.Services.ApiProvider;

public class ImageDownloadProvider : IImageDownloadProvider
{
    public ImageDownloadProvider(IGetRequestMessage getRequestMessage)
    {
        GetRequestMessage = getRequestMessage;
    }

    public IGetRequestMessage GetRequestMessage { get; }
    public IPica3Client Pica3Client { get; }

    public async Task<Stream> DownloadImage(string url)
    {
        try
        {
            var request = GetRequestMessage.GetImageMessage(HttpMethod.Get
                , url);
            var reqonse = await GetRequestMessage.ImageGetAsync(request).ConfigureAwait(false);
            return reqonse;
        }
        catch (Exception ex)
        {
            return null;
        }
    }


    public async Task<Stream> DownloadImageManhuabika(string url)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        var reqonse = await GetRequestMessage.ImageGetAsync(request).ConfigureAwait (false);
        return reqonse;
    }
}
