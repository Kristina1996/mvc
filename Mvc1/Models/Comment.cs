using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc1.Models
{
    public class Comment
    {
        public virtual int Id { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime Date { get; set; }

        public int? ArticleId { get; set; }
        public virtual Article Article { get; set; }
        public int UserId { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }
}