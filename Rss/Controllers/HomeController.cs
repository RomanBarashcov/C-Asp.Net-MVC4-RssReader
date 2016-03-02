using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rss.Models;
using System.Xml.Linq;

namespace Rss.Controllers
{
    public class HomeController : Controller
    {
        Context db =  new Context();

        public ActionResult Index()
        {
            IEnumerable<Feed> Feeds = db.Feeds;
            ViewBag.Items = Feeds;
            return View();
        }
       

        public ActionResult Delete(int id) // Удаляем  новостной какнал по id
        {
            Feed feedId = db.Feeds.Find(id);
            
            if (feedId != null)
            {
                db.Feeds.Remove(feedId);
                db.SaveChanges();
            }
            return RedirectToAction("MsgDelUrl");
        }


        public ActionResult DeleteFeed(int id)   // Удаляем новотсь, канала по Id
        {
            NewsItem NewsItemId = db.News.Find(id);
            var FeedID = NewsItemId.FeedId;

            if (NewsItemId != null)
            {
                db.News.Remove(NewsItemId);
                db.SaveChanges();
            }
            return RedirectToAction("Feed", new { id = FeedID});
        }


        public ActionResult Feed(int id)   // получаем новости из бд ПО id
        {

            var select = db.News.Where(x => x.FeedId == id).ToList();
            ViewBag.Items = select;
            ViewBag.ID = id;
            return View();
        }


        [HttpPost]
        public ActionResult AddFeed() 
        {
            ViewBag.Items = db.News;
            return View(); 
        }

        
        [HttpPost]
        public ActionResult AddNewFeed(Feed NewFeed)  // Получаем данные из формы
        {

            db.Feeds.Add(NewFeed);        // Передаем данные из формы в бд
           var UrlXml = NewFeed.Link;    // Получаем ссылку на канал

            XDocument feedXml = XDocument.Load(UrlXml);

            var news = from News in feedXml.Descendants("item")
                        select new NewsItem
                        {
                            
                            Body = News.Element("title").Value,
                            Link = News.Element("link").Value,
                              
                        };

            NewFeed.News  = news.ToList();
            db.SaveChanges();

            return RedirectToAction("MsgAdd");
          
        }

        public ActionResult MsgAdd()    //Вывод сообщения, об успешном добавлении Url
        {
            return View();
        }

        public ActionResult MsgDelUrl()   //Вывод сообщения , об  успешном удалении новостного канала и всех его новотей 
        {
            return View();
        }

    }

}
