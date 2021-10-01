using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestBookAPI.Data
{
    public class QuestRepo : IQuestRepo
    {
        private readonly QuestBookDbContext _context;

        public QuestRepo(QuestBookDbContext context){_context = context;}

        public async Task<ICollection<Quests>> GetQuests()
        {
            var q = _context.Quests;
            var ql = q.ToList();
            var qlc = ql.Count;
            return await _context.Quests.ToListAsync();
        }
    }
}