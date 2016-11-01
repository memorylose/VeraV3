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

        public IEnumerable<Articles> GetIndexArticleWithType(int beginRowNumber, int endRowNumber, int typeId)
        {
            string typeStr = string.Empty;
            if (typeId != 0)
            {
                typeStr = " and Articles.TypeId = " + typeId;
            }
            using (IDbConnection connection = dapperConnection.OpenConnection())
            {
                string query = "select A.* from (select row_number() over(order by Articles.CreateDate desc) as rownumber, Articles.ArticleId,Articles.Title,Articles.Summary,Articles.Contents,Articles.CreateDate,Articles.TypeId, ArticleType.TypeName, Users.UserName from Articles inner join Users on Articles.CreateUserId = Users.UserId inner join ArticleType on Articles.TypeId = ArticleType.TypeId " + typeStr + ") as A where A.rownumber between @beginRowNumber and @endRowNumber";
                var articles = connection.Query<Articles>(query, new { beginRowNumber = beginRowNumber, endRowNumber = endRowNumber }).ToList();
                return articles;
            }
        }

        public int GetArticlesCount()
        {
            using (IDbConnection connection = dapperConnection.OpenConnection())
            {
                const string query = "SELECT ArticleId FROM Articles";
                var articles = connection.Query<Articles>(query).Count();
                return articles;
            }
        }

        public int GetArticlesCountWithType(int typeId)
        {
            string typeStr = string.Empty;
            if (typeId != 0)
            {
                typeStr = " and TypeId = " + typeId;
            }

            using (IDbConnection connection = dapperConnection.OpenConnection())
            {
                string query = "SELECT ArticleId FROM Articles WHERE 1 = 1" + typeStr;
                var articles = connection.Query<Articles>(query).Count();
                return articles;
            }
        }

        public Articles GetArticleDetail(int articleId)
        {
            using (IDbConnection connection = dapperConnection.OpenConnection())
            {
                const string query = "select Articles.ArticleId,Articles.Title,Articles.Contents,Articles.CreateDate,Articles.TypeId,ArticleType.TypeName,Users.UserName from Articles, ArticleType, Users where Articles.TypeId = ArticleType.TypeId and Articles.CreateUserId = Users.UserId and Articles.ArticleId=@articleId";
                var articles = connection.Query<Articles>(query, new { articleId = articleId }).FirstOrDefault();
                return articles;
            }
        }

        public IEnumerable<ArticleType> GetArticleType()
        {
            using (IDbConnection connection = dapperConnection.OpenConnection())
            {
                string query = "select TypeId,TypeName from ArticleType ORDER BY TypeId ASC";
                var types = connection.Query<ArticleType>(query).ToList();
                return types;
            }
        }

        public bool AddArticle(Articles article)
        {
            bool result = false;
            string insertSql = "insert into Articles(Title, Summary, Contents,CreateDate,CreateUserId,TypeId) values (@Title,@Summary,@Contents,@CreateDate,@CreateUserId,@TypeId)";

            using (IDbConnection connection = dapperConnection.OpenConnection())
            {
                if (connection.Execute(insertSql, article) > 0)
                    result = true;
            }
            return result;
        }
    }
}
