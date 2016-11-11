using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vera.Business;
using Moq;
using Vera.Interface.DAL;
using Vera.Model;

namespace Vera.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ValidationLoginInformationWithUserNameEmpty()
        {
            var userData = new Mock<IUserDataAccess>();
            UserRepository userRep = new UserRepository(userData.Object);

            User userModel = new User() { UserName = "" };

            string result = userRep.ValidateLogin(userModel);
        }
    }
}
