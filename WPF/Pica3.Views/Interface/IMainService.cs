using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pica3.Views.Interface
{
    public interface IMainService
    {
        IHost Host { get; set; }
        public T GetService<T>() where T : class;
    }
}
