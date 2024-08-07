using LearningBlogAPI.Models;
using LearningBlogAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Collections.Generic;

namespace LearningBlogAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleService _articleService;

        public ArticlesController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet("{id}")]
        public ActionResult<Article> GetArticleById(int id)
        {
            var article = _articleService.GetArticleById(id);
            if (article == null)
            {
                return NotFound();
            }
            return Ok(article);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Article>> GetAllArticles()
        {
            var articles = _articleService.GetAllArticles();
            return Ok(articles);
        }

        [HttpPost]
        public ActionResult CreateArticle(Article article)
        {
            _articleService.CreateArticle(article);
            return CreatedAtAction(nameof(GetArticleById), new { id = article.ArticleId }, article);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateArticle(int id, Article article)
        {
            if (id != article.ArticleId)
            {
                return BadRequest();
            }
            _articleService.UpdateArticle(article);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteArticle(int id)
        {
            _articleService.DeleteArticle(id);
            return NoContent();
        }
    }
}
