using Microsoft.EntityFrameworkCore;
using LearningBlogAPI.Models;

namespace LearningBlogAPI.Data
{
    public class LearningBlogContext : DbContext
    {
        public LearningBlogContext(DbContextOptions<LearningBlogContext> options)
            : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
    }
}