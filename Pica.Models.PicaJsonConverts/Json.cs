using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System;

namespace Pica.Models.PicaJsonConverts
{
    /// <summary>
    /// 暂时不服务化
    /// </summary>
    public static class ReadJson
    {
        public static T Read<T>(Stream data)
        {
            if(data == null)
            {
                return default(T);
            }
            StreamReader reader = new StreamReader(data);
            string result = reader.ReadToEnd();
            return JsonSerializer.Deserialize<T>(result)!;
        }

        public async static Task<string> WriteToString<T>(object data)
        {
            if(data ==null)
            {
                throw new System.Exception("对象为NULL，未收到赋值的对象");
            }
            Stream stream = null;
            await JsonSerializer.SerializeAsync<T>(stream!,(T)data);
            stream.Position = 0;
            return new StreamReader(stream).ReadToEnd();
        }
    }
}
