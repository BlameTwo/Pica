using Pica.Interfaces;

namespace Pica.Services;

public class ProviderBase
{
    public IPica3Client Pica3Client { get; set; }

    public IGetRequestMessage GetRequestMessage { get; set; }
    public ProviderBase(IPica3Client pica3Client, IGetRequestMessage getRequestMessage)
    {
        Pica3Client = pica3Client;
        GetRequestMessage = getRequestMessage;
    }
}
