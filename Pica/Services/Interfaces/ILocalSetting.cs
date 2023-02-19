namespace Pica.Services.Interfaces;

public interface ILocalSetting
{
    string LocalSettingFileName { get; }

    Dictionary<string, object> Config { get; set; }

    Task SaveConfig<T>(string key, T value);

    Task<object> ReadConfig(string key);

    Task<bool> DelectConfig(string key);

    Task<bool> InitSetting();
}
