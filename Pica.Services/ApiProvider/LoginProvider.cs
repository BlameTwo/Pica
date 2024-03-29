﻿using Pica.Interfaces;
using Pica.Interfaces.Provider;
using Pica.Models.ApiModels;
using Pica.Models.ApiModels.Users;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Pica.Services.ApiProvider
{
    public class LoginProvider : ILoginProvider
    {
        public string Token { get; set; }
        public IPicaClient PicaClient { get; }
        public IGetRequestMessage GetRequestMessage { get; }

        public LoginProvider(IPicaClient pica3Client, IGetRequestMessage getRequestMessage)
        {
            PicaClient = pica3Client;
            GetRequestMessage = getRequestMessage;
        }

        public async Task<bool> LoginAsync(string account, string password)
        {
            var content = JsonContent.Create(new { email = account, password });
            var request = GetRequestMessage.GetRequestMessageAsync(HttpMethod.Post, "auth/sign-in", content,false);
            var result = await GetRequestMessage.SendAsync(request);
            
            ResultCode<LoginData> data = Pica.Models.PicaJsonConverts.ReadJson.Read<ResultCode<LoginData>>(result);
            if(data.Data != null)
            {
                //赋值token
                PicaClient.Token = data.Data.Token;
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
