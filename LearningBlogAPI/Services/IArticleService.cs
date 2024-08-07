using LearningBlogAPI.Models;

namespace LearningBlogAPI.Services
{
    public interface IArticleService
    {
        Article GetArticleById(int id);
        IEnumerable<Article> GetAllArticles();
        void UpdateArticle(Article article);
        void DeleteArticle(int id);
        void CreateArticle(Article article);
    }
}