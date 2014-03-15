using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Authentication.Demo.Tests
{
    public interface IUserService
    {
        bool RegisterUser(string userId);
    }
}
