using System.IO;
using System.Threading.Tasks;

namespace Pica.Interfaces.Provider;

public interface IImageDownloadProvider
{
    Task<Stream> DownloadImage(string url);



    public  Task<Stream> DownloadImageManhuabika(string url);
}
