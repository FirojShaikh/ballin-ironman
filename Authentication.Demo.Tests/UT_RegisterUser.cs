using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace Authentication.Demo.Tests
{

    //1.	Develop a capability to register user. 
    //2.	User name should not exists already. 
    //3.	User ID should not be empty. 
    [TestClass]
    public class UT_RegisterUser
    {
        private IUserService mUserService;
        private IUserDbContext mockUserDbContext;
        [TestInitialize]
        public void Initialize()
        {
            mockUserDbContext = MockRepository.GenerateMock<IUserDbContext>();
            mUserService = new UserService(mockUserDbContext);
        }

        [TestCleanup]
        public void Cleanup()
        {
            mockUserDbContext = null;
            mUserService = null;
        }

        [TestMethod]
        public void Should_RegisterUser()
        {
            var userId= GivenValidUserId();

            WhenRegisterUser(userId);
            
            ThenShouldRegisterUser();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Should_Not_ResgisterUser_When_User_AlreadyExists()
        {
            var userId = GivenValidUserId();

            GivenUserAlreadyExists(userId);

            WhenRegisterUser(userId);

            ThenShouldNotRegisterUser();
        }

        private string GivenValidUserId()
        {
            return "TestUser1";
        }

        private void GivenUserAlreadyExists(string userId)
        {
            mockUserDbContext.Expect(m => m.CheckUserExists(userId)).Return(true);
        }

        private void ThenShouldNotRegisterUser()
        {
            mockUserDbContext.AssertWasNotCalled(m=>m.RegisterUser(Arg<string>.Is.Anything));
        }

        private void WhenRegisterUser(string userId)
        {
            mUserService.RegisterUser(userId);
        }

        private void ThenShouldRegisterUser()
        {
            mockUserDbContext.AssertWasCalled(m=>m.RegisterUser(Arg<string>.Is.Anything));
        }
    }
}
