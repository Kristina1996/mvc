using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc1.Models
{
    public class Article
    {
        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime Date { get; set; }

        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }

 

        public int UserId { get; set; }
        public virtual UserProfile UserProfile { get; set; }

    }
}