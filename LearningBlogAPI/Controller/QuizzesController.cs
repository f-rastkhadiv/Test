using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LearningBlogAPI.Data;
using LearningBlogAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningBlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly LearningBlogContext _context;

        public QuizController(LearningBlogContext context)
        {
            _context = context;
        }

        // POST: api/Quiz
        [HttpPost]
        public async Task<ActionResult<Quiz>> CreateQuiz(Quiz quiz)
        {
            _context.Quizzes.Add(quiz);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetQuizById), new { id = quiz.QuizId }, quiz);
        }
        // GET: api/Quiz/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Quiz>> GetQuizById(int id)
        {
            var quiz = await _context.Quizzes.FindAsync(id);

            if (quiz == null)
            {
                return NotFound();
            }

            return quiz;
        }

        // GET: api/Quiz/ByArticle/{articleId}     
         [HttpGet("ByArticle/{articleId}")]
          public async Task<ActionResult<IEnumerable<Quiz>>> GetQuizzesByArticle(int articleId)
          {
            var quizzes = await _context.Quizzes.Where(q => q.ArticleId == articleId).ToListAsync();

            if (quizzes == null || quizzes.Count == 0)
            {
                return NotFound();
            }

            return quizzes;
        }
        // POST: api/Quiz/{id}/submit
        [HttpPost("{id}/submit")]
        public async Task<IActionResult> SubmitQuiz(int id, [FromBody] QuizSubmission submission)
        {
            var quiz = await _context.Quizzes.FindAsync(id);

            if (quiz == null)
            {
                return NotFound();
            }
            bool isCorrect = quiz.CorrectAnswer == submission.Answer;
            return Ok(new { Correct = isCorrect });
        }

        private bool QuizExists(int id)
        {
            return _context.Quizzes.Any(e => e.QuizId == id);
        }
    }
    public class QuizSubmission
    {
        public string Answer { get; set; }
    }
}