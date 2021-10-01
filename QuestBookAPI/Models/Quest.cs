using Microsoft.AspNetCore.Mvc;

namespace QuestBookAPI.Models
{
    public class Quest : Controller
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int estimatedCompletionTime { get; set; }
        public bool completed { get; set; }

        public IActionResult Index()
        {
            return View();
        }
    }
}