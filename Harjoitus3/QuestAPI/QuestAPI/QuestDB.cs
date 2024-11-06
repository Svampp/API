namespace QuestAPI
{
    using Microsoft.EntityFrameworkCore;
    public class QuestDB : DbContext
    {
        public QuestDB(DbContextOptions options) : base(options) { }
        public DbSet<Quest> Quests => Set<Quest>();
    }
}
