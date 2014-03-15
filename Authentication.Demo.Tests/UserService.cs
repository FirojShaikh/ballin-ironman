using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Authentication.Demo.Tests
{
    public class UserService:IUserService
    {
        private IUserDbContext mUserDbContext;

        public UserService()
        {
            
        }

        public UserService(IUserDbContext userDbContext)
        {
            mUserDbContext = userDbContext;
        }

        public bool RegisterUser(string userId)
        {
            if (mUserDbContext.CheckUserExists(userId))
            {
                throw new InvalidOperationException("User already exists");
            }
            return mUserDbContext.RegisterUser(userId);
        }
    }
}
