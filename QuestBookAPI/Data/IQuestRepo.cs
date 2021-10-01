using QuestBookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestBookAPI.Data
{
    public interface IQuestRepo
    {
        Task<ICollection<Quests>> GetQuests();
    }
}
