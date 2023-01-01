using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pica.Interfaces;
using Pica.Interfaces.Provider;
using PicaApi.Services.ApiProvider;
using PicaApi.Services.Client;

namespace PicaTest
{
    public static class Program
    {
        public async static Task Main(string[] args)
        {
            //初始化客户端，此初始化方式为变量
            IPica3Client pica3Client = AppCreate.GetService<IPica3Client>();
            ILoginProvider loginProvider = AppCreate.GetService<ILoginProvider>();
            IUserProvider userProvider = AppCreate.GetService<IUserProvider>();
            pica3Client.InitClient();

            //获得分流IP
            var str = await pica3Client.GetIpList();
            //设置分流IP
            pica3Client.SetIp(null, str.Ips[0]);
            Console.WriteLine("自动设置分流地址："+str.Ips[0]);

#if DEBUG
            //Debug模式下使用自己账号
            var result = await loginProvider.LoginAsync("18833168856", "qwe262953");
#else
            while (true)
            {
                System.Console.WriteLine("请输入账号：");
                //绿色波浪线不管他
                string username = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(username))
                {
                    Console.WriteLine("好的，现在输入此账号的密码:");
                    string password = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(password))
                    {
                        var userlogindata = await loginProvider.LoginAsync(username, password);
                        if (userlogindata)
                        {
                            Console.WriteLine("登陆成功！");
                            Console.WriteLine(AppCreate.GetService<IPica3Client>().Token);
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else
                    {
                        Console.WriteLine("请重新全部输入！");
                        continue;
                    }
                }
                else
                {
                    continue;
                }
            }
#endif

            #region 获取个人信息
            //var userdata = await userProvider.GetUserProfile();
            #endregion
            #region 哔咔签到
            var punch = await userProvider.UserPauch().ConfigureAwait(false);
            Console.WriteLine(punch.Data.Resource.Status);
            #endregion

            Console.ReadLine();
        }

    }

}