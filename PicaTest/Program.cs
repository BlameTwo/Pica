using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pica.Interfaces;
using Pica.Interfaces.Provider;
using Pica.Services.ApiProvider;
using PicaApi.Services.ApiProvider;
using PicaApi.Services.Client;
using System.Drawing;

namespace PicaTest
{
    public static class Program
    {
        public async static Task Main(string[] args)
        {
            //初始化客户端，此初始化方式为变量
            IPica3Client pica3Client = AppCreate.GetService<IPica3Client>();
            pica3Client.InitClient();
            pica3Client.imageQuality = Pica.Models.ApiModels.ImageQuality.Original;
            ILoginProvider loginProvider = AppCreate.GetService<ILoginProvider>();
            IUserProvider userProvider = AppCreate.GetService<IUserProvider>();
            IComicProvider comicProvider = AppCreate.GetService<IComicProvider>();
            ISearchProvider searchProvider = AppCreate.GetService<ISearchProvider>();
            IImageDownloadProvider imageDownloadProvider = AppCreate.GetService<IImageDownloadProvider>();

            ////获得分流IP
            //var str = await pica3Client.GetIpList();
            ////设置分流IP
            //pica3Client.SetIp(null, str.Ips[0]);
            //Console.WriteLine("自动设置分流地址："+str.Ips[0]);

#if DEBUG
            //Debug模式下使用自己账号
            var result = await loginProvider.LoginAsync("18833168856", "qwe262953")
                .ConfigureAwait(false);

            if (result)
                Console.WriteLine("登陆成功");
            else
            {
                //直接退出程序
                Console.WriteLine("登录失败！请重新打开程序重新登陆！");
                System.Environment.Exit(0);
            }

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
            //var punch = await userProvider.UserPauch().ConfigureAwait(false);
            //Console.WriteLine("签到状态"+punch.Data.Resource.Status);
            #endregion

            #region 漫画操作
            #region 个人收藏漫画
            //var myfav = await userProvider.GetUserFavourite();
            //Console.WriteLine("我的收藏");
            //foreach (var item in myfav.Data.Comics.Docs)
            //{
                //Console.WriteLine(item.Title);
            //}
            #endregion

            #region 搜索漫画
            //var searchdata = await comicProvider.SearchComic("genshin", 1);
            //Console.WriteLine(searchdata);
            #endregion

            #region 获取漫画详情
            //var comicdetail = await comicProvider.GetComicDetail("63adb53484e1f369d2bda06e");
            var pages = await comicProvider.GetComicPages("63adb53484e1f369d2bda06e", "1", 1);
            var url = pages.Data.Pages.Documents[0].FileSource.Path.Substring(pages.Data.Pages.Documents[0].FileSource.Path.IndexOf("/")+1);
            var stream = await imageDownloadProvider.DownloadImageManhuabika("http://img.manhuabika.com/" + url);
            Bitmap bitmap = new(stream);
            bitmap.Save("D:\\test.jpg");
            //Console.WriteLine(comicdetail);
            #endregion

            #region 获取漫画章节信息
            var comicpages = await comicProvider.GetComicEpisode("63adb53484e1f369d2bda06e", 1);
            Console.WriteLine(comicpages);
            #endregion

            #region 获得随机本子
            var randomcomic = await comicProvider.GetRandomComic().ConfigureAwait(false);
            #endregion
            #endregion

            #region 搜索操作
            #region 关联搜索
            //var keylists = await searchProvider.SearchKeys();
            //foreach (var item in keylists.Data.KeyWords)
            //{
            //    await Console.Out.WriteLineAsync(item);
            //}
            #endregion

            #region 关键字搜索
            //var keysearch = await searchProvider.Search("NTR", 1, Pica.Models.ApiModels.SortType.ua,null);
            #endregion

            #endregion

            Console.ReadLine();
        }

    }

}