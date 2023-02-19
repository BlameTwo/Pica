using Pica.Services.Interfaces;
using System.Text.Json;

namespace Pica.Services
{
    public class LocalSetting : ILocalSetting
    {
        public string LocalSettingFileName => "PicaSetting.json";

        string filedir = FileSystem.Current.AppDataDirectory;

        string file
        {
            get
            {
                return Path.Combine(filedir, LocalSettingFileName);
            }
        }

        public Dictionary<string, object> Config { get; set; }

        public async Task<bool> InitSetting()
        {
            if (!File.Exists(Path.Combine(filedir, LocalSettingFileName)))
            {
                await initWrite();
                return true;
            }
            string filestr = File.ReadAllText(file);
            if(!string.IsNullOrWhiteSpace(filestr))
            {
                await refresh();
            }
            return true;
        }

        private async Task initWrite()
        {
            await File.WriteAllTextAsync(Path.Combine(filedir, LocalSettingFileName),"");
        }

        async Task refresh()
        {
            var str = await File.ReadAllTextAsync(file);
            if (!string.IsNullOrWhiteSpace(str))
            {
                Config = JsonSerializer.Deserialize<Dictionary<string, object>>(str);
            }
            else
                Config = new();
        }

        public async Task<Object> ReadConfig(string key)
        {
            await refresh();
            if(Config.ContainsKey(key) )
            {
                object ob = null;
                Config.TryGetValue(key, out ob);
                if(ob is JsonElement json && json.ValueKind == JsonValueKind.String)
                {
                    return json.GetString();
                }
                return ob;
            }
            else
            {
                return default(object);
            }
        }

        public async Task SaveConfig<T>(string key, T value)
        {
            await refresh();
            if(Config.ContainsKey(key) )
            {
                Config[key] = value;
            }
            else
            {
                Config.Add(key, value);
            }
            await save();
        }

        public async Task save()
        {
            await File.WriteAllTextAsync(Path.Combine(filedir, LocalSettingFileName), JsonSerializer.Serialize(Config));
        }

        public async Task<bool> DelectConfig(string key)
        {
            if (Config.ContainsKey(key))
            {
                Config.Remove(key);
                await save();
                return true;
            }
            return false;
        }
    }
}
