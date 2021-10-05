using Microsoft.EntityFrameworkCore;
using QuestBookAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuestBookAPI.Data
{
    public class QuestRepo : IQuestRepo
    {
        private readonly QuestBookDbContext _context;

        public QuestRepo(QuestBookDbContext context)
        {
            _context = context;
        }

        public async Task CreateQuest(Quest quest)
        {
            await _context.Quest.AddAsync(quest);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Quest>> GetQuests()
        {/*
            var q = _context.Quest;
            var ql = q.ToList();
            var qlc = ql.Count;*/
            return await _context.Quest.ToListAsync();
        }

        public async Task<Quest> GetQuest(int Id)
        {
            Quest quest = await _context.Quest.FirstOrDefaultAsync(q => q.Id == Id);
            return quest;
        }

        public async Task UpdateQuest(Quest questInDb, Quest newQuest)
        {
            questInDb.Name = newQuest.Name;
            questInDb.Description = newQuest.Description;
            questInDb.EstimatedCompletionTime = newQuest.EstimatedCompletionTime;
            questInDb.Completed = newQuest.Completed;

            _context.Entry(questInDb).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteQuest(Quest quest)
        {
            _context.Entry(quest).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}