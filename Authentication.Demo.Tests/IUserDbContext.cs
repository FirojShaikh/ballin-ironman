using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Authentication.Demo.Tests
{
    public interface IUserDbContext
    {
        bool RegisterUser(string user);

        bool CheckUserExists(string userId);
    }

    public class UserDbContext : IUserDbContext
    {
        public bool RegisterUser(string user)
        {
            throw new NotImplementedException();
        }


        public bool CheckUserExists(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
