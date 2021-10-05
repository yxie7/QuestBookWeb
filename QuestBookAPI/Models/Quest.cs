namespace QuestBookAPI.Models
{
    public class Quest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int? EstimatedCompletionTime { get; set; }
        public bool? Completed { get; set; }
    }
}