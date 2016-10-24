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
    }
}
