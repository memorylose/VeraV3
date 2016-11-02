using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vera.Interface.DAL;
using Dapper;
using Vera.Model;
using Vera.Utility;

namespace Vera.DataAccess.Dapper
{
    public class UserDal : IUserDataAccess
    {
        private IDapperConnection dapperConnection;
        public UserDal(IDapperConnection _dapperConnection)
        {
            dapperConnection = _dapperConnection;
        }

        public bool Login(User userModel)
        {
            using (IDbConnection connection = dapperConnection.OpenConnection())
            {
                const string query = "SELECT UserId FROM Users WHERE UserName = @UserName AND Password = @Password";
                int i = connection.Query<User>(query, new { UserName = userModel.UserName, Password = EncryptUtil.CreateSHA256HashString(userModel.Password) }).Count();
                if (i > 0)
                    return true;
                else
                    return false;
            }
        }

        public int GetUserIdByUserName(string userName)
        {
            using (IDbConnection connection = dapperConnection.OpenConnection())
            {
                const string query = "SELECT UserId FROM Users WHERE UserName = @UserName";
                var user = connection.Query<User>(query, new { UserName = userName }).SingleOrDefault();
                return user.UserId;
            }
        }

        public UserInformation GetUserInfoByUserId(int userId)
        {
            using (IDbConnection connection = dapperConnection.OpenConnection())
            {
                const string query = "SELECT NickName, Gender, Profession, Major FROM UserInformation WHERE UserId = @UserId";
                var user = connection.Query<UserInformation>(query, new { UserId = userId }).SingleOrDefault();
                return user;
            }
        }

        public User GetUserByUserId(int userId)
        {
            using (IDbConnection connection = dapperConnection.OpenConnection())
            {
                const string query = "SELECT UserId, UserName, Email, CreateDate,UpdateDate,Password FROM Users WHERE UserId = @UserId";
                var user = connection.Query<User>(query, new { UserId = userId }).SingleOrDefault();
                return user;
            }
        }

        public int CreateUser(User model)
        {
            int userId = 0;
            string userSql = "INSERT INTO Users(UserName,Password,Email,CreateDate,UpdateDate) VALUES(@UserName,@Password,@Email,@CreateDate,@UpdateDate);SELECT CAST(SCOPE_IDENTITY() as int)";
            using (IDbConnection connection = dapperConnection.OpenConnection())
            {
                userId = connection.Query<int>(userSql, new { UserName = model.UserName, Password = EncryptUtil.CreateSHA256HashString(model.Password), Email = model.Email, CreateDate = model.CreateDate, UpdateDate = model.UpdateDate }).Single();
            }
            return userId;
        }

        public bool CreateUserInformation(UserInformation model)
        {
            bool result = false;
            string userSql = "INSERT INTO UserInformation(UserId,NickName,Gender,Profession,Major,Signature) VALUES(@UserId,@NickName,@Gender,@Profession,@Major,@Signature)";
            using (IDbConnection connection = dapperConnection.OpenConnection())
            {
                if (connection.Execute(userSql, model) > 0)
                    result = true;
            }
            return result;
        }
    }
}
