using QuestBookAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuestBookAPI.Data
{
    public interface IQuestRepo
    {
        Task CreateQuest(Quest quest);

        Task<ICollection<Quest>> GetQuests();

        Task<Quest> GetQuest(int Id);

        Task UpdateQuest(Quest questInDb, Quest newQuest);

        Task DeleteQuest(Quest quest);
    }
}