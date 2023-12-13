using Pica.Interfaces;

namespace Pica.Helper;

public static class PicaImageHelper
{
    /// <summary>
    /// 转换图片URI
    /// </summary>
    /// <param name="pica3Client">客户端</param>
    /// <param name="url">图片地址</param>
    /// <param name="splitpath">是否包含Server地址</param>
    /// <returns></returns>
    public static string GetConvertImage(IPicaClient pica3Client,string url,bool splitpath=false)
    {

        string host = pica3Client.GetIp().Host;
        if (splitpath == true)
        {
            Uri uri = new(url);
            return $"https://{host}//{uri.PathAndQuery}";
        }
        return $"http://{host}/{url}";
    }
}
