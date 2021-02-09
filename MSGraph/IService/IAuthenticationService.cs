using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSGraph.IService
{
    public interface IAuthenticationService
    {
        Task<dynamic> GetAuthenticationInfo(string accessToken);
    }
}
