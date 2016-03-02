using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Rss.Models
{
    public class NewsItem
    {
        public int NewsItemId { get; set; }
        public string Body { get; set; }
        [DisplayName("News Title")]
        public string Title { get; set; }
        public string Link { get; set; }
        public int FeedId { get; set; }
        public Feed Feed { get; set; }
    }
}