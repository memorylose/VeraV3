using System;

namespace Vera.Model
{
    public class Articles
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Contents { get; set; }
        public int TypeId { get; set; }
        public int CreateUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public int rownumber { get; set; }
        public string TypeName { get; set; }
        public string UserName { get; set; }
    }

    public class ArticleType
    {
        public int TypeId { get; set; }
        public string TypeName { get; set; }
    }

    public class IndexType
    {
        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public int TypeCount { get; set; }
    }

    public class IndexDate
    {
        public int DateCount { get; set; }
        public string CrDate { get; set; }
    }
}
