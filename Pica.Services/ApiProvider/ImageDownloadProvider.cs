using Pica.Interfaces;
using Pica.Interfaces.Provider;
using System;
using System.IO;
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

    public async Task<Stream> DownloadImage(string url)
    {
        var request = GetRequestMessage.GetImageMessage(HttpMethod.Get
            ,url);
        var reqonse = await GetRequestMessage.ImageGetAsync(request).ConfigureAwait(false);
        return reqonse;
    }
}
