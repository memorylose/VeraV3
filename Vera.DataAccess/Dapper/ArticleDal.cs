using System.Collections.Generic;
using System.Data;
using System.Linq;
using Vera.Model;
using Dapper;
using Vera.Interface.DAL;

namespace Vera.DataAccess.Dapper
{
    public class ArticleDal : IArticleDataAccess
    {
        private IDapperConnection dapperConnection;
        public ArticleDal(IDapperConnection _dapperConnection)
        {
            dapperConnection = _dapperConnection;
        }

        public IEnumerable<Articles> GetArticles()
        {
            using (IDbConnection connection = dapperConnection.OpenConnection())
            {
                const string query = "SELECT ArticleId, Title, Summary, Contents,TypeId,CreateUserId,CreateDate FROM Articles ORDER BY ArticleId DESC";
                var articles = connection.Query<Articles>(query).ToList();
                return articles;
            }
        }

        public IEnumerable<Articles> GetHotArticles()
        {
            using (IDbConnection connection = dapperConnection.OpenConnection())
            {
                const string query = "SELECT TOP 10 ArticleId, Title, Summary, Contents,TypeId,CreateUserId,CreateDate FROM Articles ORDER BY ArticleId DESC";
                var articles = connection.Query<Articles>(query).ToList();
                return articles;
            }
        }
    }
}
