using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestBookAPI.Data
{
    public class QuestBookDbContext: DbContext
    {
        public QuestBookDbContext(DbContextOptions<QuestBookDbContext> options): base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Quests> Quests { get; set; }

    }
}
