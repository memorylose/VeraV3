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
    }

    public class ArticleType
    {
        public int TypeId { get; set; }
        public string TypeName { get; set; }
    }
}
