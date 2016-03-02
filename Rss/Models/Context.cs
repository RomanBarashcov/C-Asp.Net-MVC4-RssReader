using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Rss.Models
{
    public class Context : DbContext
    {

        public Context(string connString): base(connString)
        {}
        public Context()
            : this("rssConn")
        { }
        public DbSet<NewsItem> News { get; set; }
        public DbSet<Feed> Feeds { get; set; }
    }
}