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
        Mock<IUserDataAccess> userMocker;
        public UserTest()
        {
            userMocker = new Mock<IUserDataAccess>();
        }

        [TestMethod]
        public void ValidationLoginInformationWithUserNameEmpty()
        {
            UserRepository userRep = new UserRepository(userMocker.Object);
            User userModel = new User() { UserName = "" };
            string result = userRep.ValidateLogin(userModel);
            Assert.AreEqual(result, "用户名不能为空");
        }

        [TestMethod]
        public void ValidationLoginInformationWithPasswordEmpty()
        {
            UserRepository userRep = new UserRepository(userMocker.Object);
            User userModel = new User() { UserName = "Test", Password = "" };
            string result = userRep.ValidateLogin(userModel);
            Assert.AreEqual(result, "密码不能为空");
        }

        [TestMethod]
        public void ValidationLoginInformationSuccessfully()
        {
            UserRepository userRep = new UserRepository(userMocker.Object);
            User userModel = new User() { UserName = "Test", Password = "Test" };
            string result = userRep.ValidateLogin(userModel);
            Assert.AreEqual(result, "");
        }
    }
}
