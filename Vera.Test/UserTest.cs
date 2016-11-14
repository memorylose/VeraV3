using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vera.Interface.DAL;
using Moq;
using Vera.Business;
using Vera.Model;

namespace Vera.Test
{
    /// <summary>
    /// Summary description for UserTest
    /// </summary>
    [TestClass]
    public class UserTest
    {
        UserRepository userRep;
        Mock<IUserDataAccess> userMocker;
        public UserTest()
        {
            userMocker = new Mock<IUserDataAccess>();
            userRep = new UserRepository(userMocker.Object);
        }

        [TestMethod]
        public void ValidationLoginInformationWithUserNameEmpty()
        {
            User userModel = new User() { UserName = "" };
            string result = userRep.ValidateLogin(userModel);
            Assert.AreEqual(result, "用户名不能为空");
        }

        [TestMethod]
        public void ValidationLoginInformationWithPasswordEmpty()
        {
            User userModel = new User() { UserName = "Test", Password = "" };
            string result = userRep.ValidateLogin(userModel);
            Assert.AreEqual(result, "密码不能为空");
        }

        [TestMethod]
        public void ValidationLoginInformationSuccessfully()
        {
            User userModel = new User() { UserName = "Test", Password = "Test" };
            string result = userRep.ValidateLogin(userModel);
            Assert.AreEqual(result, "");
        }

        [TestMethod]
        public void ValidateLoginFailed()
        {

        }
    }
}
