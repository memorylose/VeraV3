﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vera.Model;

namespace Vera.Interface.BLL
{
    public interface IArticleRepository
    {
        IEnumerable<Articles> GetArticles();
        IEnumerable<Articles> GetHotArticles();
        IEnumerable<IndexType> GetIndexArticleType();
        IEnumerable<IndexDate> GetIndexArticleDate();
        IEnumerable<Articles> GetIndexArticle(int beginRowNumber, int endRowNumber);
        int GetArticlesCount();
        Articles GetArticleDetail(int articleId);
        IEnumerable<Articles> GetIndexArticleWithType(int beginRowNumber, int endRowNumber, int typeId);
        int GetArticlesCountWithType(int typeId);
        IEnumerable<ArticleType> GetArticleType();
        string AddArticleValidation(Articles article);
        bool AddArticle(Articles article);
    }
}
