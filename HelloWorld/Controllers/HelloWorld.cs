using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloWorld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private static readonly List<News> NewsList = new List<News>
        {
            new News{NewsId=1,Title="Windows Froms",Content="天啊好多要學"},
            new News{NewsId=2,Title="LINQ",Content="是Q不是K"},
            new News{NewsId=3,Title="IIS",Content="這個是什麼還沒學"},
            new News{NewsId=4,Title="PostMan",Content="是個好用的工具"}
        };

        // GET: api/News
        [HttpGet]
        public IEnumerable<HelloWorld.News> Get()
        {
            return NewsList;
        }

        // GET api/news/id
        //查詢指定新聞
        [HttpGet("{id}")]
        public ActionResult<News> Get(int id)
        {
            var result = from a in NewsList
                         where a.NewsId == id
                         select a;
            //result = NewsList.Where(a => a.NewsId == id);
            if (result == null)
            {
                return NotFound();   
            }
            return Ok(result);

        }
        //新增
        // POST api/<HelloWorld>
        [HttpPost]
        public IEnumerable<News> Post(News value)
        {
            NewsList.Add(value);
            return NewsList;
        }


        //修改
        // PUT api/news/id
        [HttpPut("{id}")]
        public IEnumerable<News> Put(int id, News value)
        {
            var update = (from a in NewsList
                          where a.NewsId == id
                          select a).SingleOrDefault();
            update = NewsList.SingleOrDefault(a => a.NewsId == id);

            if (update != null)
            {
                update.Title = value.Title;
                update.Content = value.Content;
            }

            return NewsList;
        }

        

      

        // DELETE api/news/5
        [HttpDelete("{id}")]
        public ActionResult<IEnumerable<HelloWorld.News>> Delete(int id)
        {
            var delete = (from a in NewsList
                          where a.NewsId == id
                          select a).SingleOrDefault();
            //delete = NewsList.SingleOrDefault(a => a.NewsId == id);
            if (delete == null)
            {
                return NotFound();
            }

            NewsList.Remove(delete);
            return Ok(NewsList);
        }
        
        
    }
}
