using Xunit;
using LearningBlogAPI.Controllers;
using LearningBlogAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using LearningBlogAPI.Services;
 

namespace LearningBlogAPI.Tests
{
    public class ArticlesControllerTests
    {
        private readonly ArticlesController _controller;
        private readonly Mock<IArticleService> _mockService;

        public ArticlesControllerTests()
        {
            _mockService = new Mock<IArticleService>();
            _controller = new ArticlesController(_mockService.Object);
        }

[Fact]
        public void GetArticleById_ReturnsOkResult_WhenArticleExists()
        {
            // Arrange
            var articleId = 1;
            var article = new Article { ArticleId = articleId, Title = "Test Article" };
            _mockService.Setup(service => service.GetArticleById(articleId)).Returns(article);

            // Act
            var result = _controller.GetArticleById(articleId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedArticle = Assert.IsType<Article>(okResult.Value);
            Assert.Equal(articleId, returnedArticle.ArticleId);
        }

[Fact]
        public void GetAllArticles_ReturnsAllArticles()
        {
            var articles = new List<Article>
            {
                new Article { ArticleId = 1, Title = "Article 1" },
                new Article { ArticleId = 2, Title = "Article 2" }
            };
            _mockService.Setup(service => service.GetAllArticles()).Returns(articles);
            var result = _controller.GetAllArticles();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedArticles = Assert.IsType<List<Article>>(okResult.Value);
            Assert.Equal(2, returnedArticles.Count);
        }
    }
}