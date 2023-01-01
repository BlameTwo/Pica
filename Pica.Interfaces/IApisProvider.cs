using Pica.Models.ApiModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pica.Interfaces
{
    public interface IApisProvider
    {
        string DefaultUA { get; set; }
        string DefaultAccept { get; set; }
        byte[] SignatureKey { get; }
        string TimeStamp { get; set; }

        int AppChannel { get; set; }

        string ApiKey { get; set; }
        string AppVersion { get; set; }
        string AppBuildVersion { get; set; }
        string Nonce { get; set; }

        ImageQuality ImageQuality { get; set; }
        string AppPlatform { get; set; }

        string AppUuid { get; set; }
    }
}
