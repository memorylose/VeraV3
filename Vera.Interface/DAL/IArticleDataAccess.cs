﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vera.Model;

namespace Vera.Interface.DAL
{
    public interface IArticleDataAccess
    {
        IEnumerable<Articles> GetArticles();
        IEnumerable<Articles> GetHotArticles();
    }
}