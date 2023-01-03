using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pica3.Views.Interface;
namespace Pica3.Views
{
    public class MainService : IMainService
    {
        public IHost Host
        {
            get;set;
        }

        public T GetService<T>() where T : class
        {
            try
            {
                return Host.Services.GetService<T>()!;
            }
            catch (System.Exception)
            {
                throw new System.Exception("请在Pica3的生命周期管理器中注册该内容");
            }
        }
    }
}
