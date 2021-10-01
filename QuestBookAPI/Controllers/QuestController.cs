using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using QuestBookAPI.Data;

namespace QuestBookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestController : Controller
    {
        private readonly IQuestRepo _questRepo;
        private readonly QuestBookDbContext _context;
        private readonly IConfiguration _configuration;

        public QuestController(IQuestRepo questRepo, QuestBookDbContext context, IConfiguration config)
        {
            _questRepo = questRepo;
            _configuration = config;
            _context = context;
        }

        [HttpGet("GetQuests")]
        public async Task<ActionResult<ICollection<Quests>>> GetQuests()
        {
            try
            {
                var questList = await _questRepo.GetQuests();
                if (questList.Count == 0)
                {
                    return StatusCode(404, "No quest found");
                }
                return Ok(questList);
            }
            catch(Exception)
            {
                return StatusCode(505, "An error has occured.");
            }
        }

    }
}
