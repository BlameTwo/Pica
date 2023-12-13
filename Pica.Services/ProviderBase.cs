using Pica.Interfaces;

namespace Pica.Services;

public class ProviderBase
{
    public IPicaClient PicaClient { get; set; }

    public IGetRequestMessage GetRequestMessage { get; set; }
    public ProviderBase(IPicaClient pica3Client, IGetRequestMessage getRequestMessage)
    {
        PicaClient = pica3Client;
        GetRequestMessage = getRequestMessage;
    }
}
