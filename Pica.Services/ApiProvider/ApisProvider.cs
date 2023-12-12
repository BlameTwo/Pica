using Pica.Interfaces;
using Pica.Models.ApiModels;
using System;

namespace PicaApi.Services.ApiProvider
{
    public class ApisProvider : IApisProvider
    {
        public byte[] SignatureKey => "~d}$Q7$eIni=V)9\\RK/P.RM4;9[7|@/CA}b~OW!3?EV`:<>M7pddUBL5n|0/*Cn"u8.ToArray();
        public int AppChannel { get; set; } = 1;
        public ImageQuality ImageQuality { get; set; } = ImageQuality.Original;
        string IApisProvider.TimeStamp { get; set; } = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
        string IApisProvider.DefaultUA { get; set; } = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:120.0) Gecko/20100101 Firefox/120.0";
        string IApisProvider.DefaultAccept { get; set; } = "application/vnd.picacomic.com.v1+json";
        string IApisProvider.ApiKey { get; set; } = "C69BAF41DA5ABD1FFEDC6D2FEA56B";
        string IApisProvider.AppVersion { get; set; } = "2.2.1.2.3.4";
        string IApisProvider.AppBuildVersion { get; set; } = "45";
        string IApisProvider.Nonce { get; set; } = Guid.NewGuid().ToString("N");
        string IApisProvider.AppPlatform { get; set; } = "android";

        string IApisProvider.AppUuid { get; set; } = "webUUID";
    }
}
