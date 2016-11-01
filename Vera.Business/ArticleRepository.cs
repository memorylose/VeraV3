using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vera.Interface.BLL;
using Vera.Interface.DAL;
using Vera.Model;

namespace Vera.Business
{
    public class ArticleRepository : IArticleRepository
    {
        private IArticleDataAccess article;
        public ArticleRepository(IArticleDataAccess _article)
        {
            article = _article;
        }

        public IEnumerable<Articles> GetArticles()
        {
            return article.GetArticles();
        }

        public IEnumerable<Articles> GetHotArticles()
        {
            return article.GetHotArticles();
        }

        public IEnumerable<IndexType> GetIndexArticleType()
        {
            return article.GetIndexArticleType();
        }

        public IEnumerable<IndexDate> GetIndexArticleDate()
        {
            return article.GetIndexArticleDate();
        }

        public IEnumerable<Articles> GetIndexArticle(int beginRowNumber, int endRowNumber)
        {
            return article.GetIndexArticle(beginRowNumber, endRowNumber);
        }

        public int GetArticlesCount()
        {
            return article.GetArticlesCount();
        }

        public Articles GetArticleDetail(int articleId)
        {
            return article.GetArticleDetail(articleId);
        }

        public IEnumerable<Articles> GetIndexArticleWithType(int beginRowNumber, int endRowNumber, int typeId)
        {
            return article.GetIndexArticleWithType(beginRowNumber, endRowNumber, typeId);
        }

        public int GetArticlesCountWithType(int typeId)
        {
            return article.GetArticlesCountWithType(typeId);
        }

        public IEnumerable<ArticleType> GetArticleType()
        {
            return article.GetArticleType();
        }

        public string AddArticleValidation(Articles article)
        {
            string errMsg = string.Empty;
            if (string.IsNullOrEmpty(article.Title))
            {
                errMsg = "文章标题不能为空";
            }
            else if (string.IsNullOrEmpty(article.Contents))
            {
                errMsg = "文章内容不能为空";
            }
            return errMsg;
        }

        public bool AddArticle(Articles model)
        {
            return article.AddArticle(model);
        }
    }
}
