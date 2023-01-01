using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pica.Interfaces.Provider
{
    public interface ILoginProvider
    {
        string Token { get; set; }


        Task<bool> LoginAsync(string account,string password);

    }
}
