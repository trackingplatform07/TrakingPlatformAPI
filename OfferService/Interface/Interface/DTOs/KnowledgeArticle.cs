namespace Interface.DTOs
{
    public class KnowledgeArticle
    {
        public long Id { get; set; }
        public string Category { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Summary { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }
        public bool? IsActive { get; set; }
    }
}
