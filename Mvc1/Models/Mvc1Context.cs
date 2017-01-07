using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Mvc1.Models
{
    public class Mvc1Context : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<UserProfile> UserProfile { get; set; }

   
    }
}