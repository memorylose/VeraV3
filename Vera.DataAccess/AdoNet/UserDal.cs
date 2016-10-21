using System;
using System.Data;
using System.Data.SqlClient;
using Vera.Interface.DAL;
using Vera.Utility;

namespace Vera.DataAccess.AdoNet
{
    public class UserDal : IUserDataAccess
    {
        public bool Login(string username, string password)
        {
            string sqlStr = "select count(*) from Users where UserName = @username and Password = @password";
            SqlParameter[] sqlParam = {
                    new SqlParameter("@username",SqlDbType.NVarChar,20),
                    new SqlParameter("@password",SqlDbType.NVarChar,50)
                };
            sqlParam[0].Value = username;
            sqlParam[1].Value = EncryptUtil.CreateSHA256HashString(password);

            object result = SqlHelper.ExcuteScalar(CommandType.Text, sqlStr, sqlParam);
            int i = Convert.ToInt32(result);
            if (i > 0)
                return true;
            else
                return false;
        }
    }
}
