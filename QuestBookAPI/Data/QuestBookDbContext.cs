using Microsoft.EntityFrameworkCore;
using QuestBookAPI.Models;

namespace QuestBookAPI.Data
{
    public class QuestBookDbContext : DbContext
    {
        public QuestBookDbContext(DbContextOptions<QuestBookDbContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        public DbSet<Quest> Quest { get; set; }
    }
}