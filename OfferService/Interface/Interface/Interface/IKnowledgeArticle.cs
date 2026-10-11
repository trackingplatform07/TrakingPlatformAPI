using Interface.DTOs;

namespace Interface.Interface
{
    public interface IKnowledgeArticle
    {
        Task<IEnumerable<KnowledgeArticleDTO>> SearchAsync(string? search, string? category);
    }
}
