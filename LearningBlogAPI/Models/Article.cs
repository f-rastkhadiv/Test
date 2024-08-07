namespace LearningBlogAPI.Models
{
    public class Article
    {
        public int ArticleId {get; set;}
        public string Title {get; set;}
        public string Content {get; set;}
        public string Author {get; set;}
        public DateTime PublishedDate {get; set;}
        public List<Quiz> Quizzes {get; set;}
    }
}