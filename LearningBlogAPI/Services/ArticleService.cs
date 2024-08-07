using System.Collections.Generic;
using System.Linq;
using LearningBlogAPI.Models;
using LearningBlogAPI.Services;
using LearningBlogAPI.Data;
namespace LearningBlogAPI.Services
{
    public class ArticleService : IArticleService
    {
        private readonly LearningBlogContext _context;

        public ArticleService(LearningBlogContext context)
        {
            _context = context;
        }

        public Article GetArticleById(int id)
        {
            return _context.Articles.Find(id);
        }

        public IEnumerable<Article> GetAllArticles()
        {
            return _context.Articles.ToList();
        }

        public void CreateArticle(Article article)
        {
            _context.Articles.Add(article);
            _context.SaveChanges();
        }

        public void UpdateArticle(Article article)
        {
            _context.Articles.Update(article);
            _context.SaveChanges();
        }

        public void DeleteArticle(int id)
        {
            var article = _context.Articles.Find(id);
            if (article != null)
            {
                _context.Articles.Remove(article);
                _context.SaveChanges();
            }
        }
    }
}
