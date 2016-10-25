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

        public IEnumerable<IndexType> GetIndexArticleType()
        {
            using (IDbConnection connection = dapperConnection.OpenConnection())
            {
                const string query = "select count(Articles.ArticleId) TypeCount, ArticleType.TypeName, ArticleType.TypeId from ArticleType left join Articles on ArticleType.TypeId = Articles.TypeId group by ArticleType.TypeId, ArticleType.TypeName";
                var articles = connection.Query<IndexType>(query).ToList();
                return articles;
            }
        }

        public IEnumerable<IndexDate> GetIndexArticleDate()
        {
            using (IDbConnection connection = dapperConnection.OpenConnection())
            {
                const string query = "select convert(varchar(7),CreateDate,120) as CrDate, Count(ArticleId) as DateCount from Articles group by convert(varchar(7),CreateDate,120)";
                var articles = connection.Query<IndexDate>(query).ToList();
                return articles;
            }
        }

        public IEnumerable<Articles> GetIndexArticle(int beginRowNumber, int endRowNumber)
        {
            using (IDbConnection connection = dapperConnection.OpenConnection())
            {
                const string query = "select A.* from (select row_number() over(order by Articles.CreateDate desc) as rownumber, Articles.ArticleId,Articles.Title,Articles.Summary,Articles.Contents,Articles.CreateDate,Articles.TypeId, ArticleType.TypeName, Users.UserName from Articles inner join Users on Articles.CreateUserId = Users.UserId inner join ArticleType on Articles.TypeId = ArticleType.TypeId) as A where A.rownumber between @beginRowNumber and @endRowNumber";
                var articles = connection.Query<Articles>(query, new { beginRowNumber = beginRowNumber, endRowNumber = endRowNumber }).ToList();
                return articles;
            }
        }
    }
}
