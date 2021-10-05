using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using QuestBookAPI.Data;
using QuestBookAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuestBookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestController : Controller
    {
        private readonly IQuestRepo _questRepo;

        public QuestController(IQuestRepo questRepo, QuestBookDbContext context, IConfiguration config)
        {
            _questRepo = questRepo;
        }

        [HttpGet("GetQuests")]
        public async Task<ActionResult<ICollection<Quest>>> GetQuests()
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
            catch (Exception)
            {
                return StatusCode(505, "An error has occured.");
            }
        }

        [HttpGet("GetQuest/{Id}")]
        public async Task<ActionResult<Quest>> GetQuest(int Id)
        {
            try
            {
                var quest = await _questRepo.GetQuest(Id);
                if (quest != null) return quest;
                else return StatusCode(404, "No quest found");
            }
            catch (Exception)
            {
                return StatusCode(505, "An error has occured.");
            }
        }

        [HttpPost("CreateQuest")]
        public async Task<ActionResult> CreateQuest([FromBody] Quest quest)
        {
            if (quest == null)
                return StatusCode(404, "No quest data found");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _questRepo.CreateQuest(quest);
            // Ok or CreatedAtAction
            return CreatedAtAction(nameof(GetQuest), new { Id = quest.Id }, quest);
        }

        [HttpPut("UpdateQuest/{Id}")]
        public async Task<ActionResult> UpdateQuest(int Id, [FromBody] Quest quest)
        {
            try
            {
                var questInDb = await _questRepo.GetQuest(Id);
                if (questInDb == null || quest == null || questInDb.Id != quest.Id)
                    return StatusCode(404, "No quest data found");
                await _questRepo.UpdateQuest(questInDb, quest);
                return Ok(quest);
            }
            catch (Exception)
            {
                return StatusCode(505, "An error has occured.");
            }
        }

        [HttpDelete("DeleteQuest/{Id}")]
        public async Task<ActionResult> DeleteQuest(int Id)
        {
            try
            {
                var questInDb = await _questRepo.GetQuest(Id);
                if (questInDb == null)
                    return StatusCode(404, "No quest data found");
                await _questRepo.DeleteQuest(questInDb);
                return Ok(await _questRepo.GetQuests());
            }
            catch (Exception)
            {
                return StatusCode(505, "An error has occured.");
            }
        }
    }
}