using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Rss.Models
{
    public class Feed
    {
        public int FeedId { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public virtual ICollection<NewsItem> News { get; set; }

    }
}