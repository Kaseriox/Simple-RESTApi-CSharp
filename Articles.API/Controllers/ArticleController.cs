using Articles.API.Exceptions;
using Articles.API.Repository.Article;
using Articles.API.Repository.Topic;
using Articles.API.Repository.User;
using Articles.Contract.Article;
using Database.Data;
using Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Articles.API.Controllers;
[ApiController]
[Route("article")]
public class ArticleController : ControllerBase, ICRUD<ArticleRequest>
{
    private readonly IArticleRepository _articleRepository;

    public ArticleController(IArticleRepository articleRepository)
    {
        _articleRepository = articleRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        try
        {
            return Ok(await _articleRepository.GetAll().ToListAsync());
        }
        catch (DatabaseException e)
        {
            Console.WriteLine(e);
            return Problem(e.Message);
        }
        
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            return Ok(await _articleRepository.GetById(id));
        }
        catch (DatabaseException e)
        {
            Console.WriteLine(e);
            return Problem(e.Message);
        }
        
    }
    [HttpPost]
    public async Task<IActionResult> Add(ArticleRequest articleRequest)
    {
        try
        {
            var user = new UserRepository(new ArticleContext()).GetById(articleRequest.UserId);
            var topic = new TopicRepository(new ArticleContext()).GetById(articleRequest.TopicId);
            if (user == null)
            {
                return NotFound("User Not Found");
            }
            if (topic == null)
            {
                return NotFound("Topic Not Found");
            }
            var article = new Article()
            {
                Title = articleRequest.Title,
                Body = articleRequest.Body,
                TopicId = articleRequest.TopicId,
                UserId = articleRequest.UserId
            };
            await _articleRepository.Create(article);
            return Ok();
        }
        catch (DatabaseException e)
        {
            Console.WriteLine(e);
            return Problem(e.Message);
        }
        
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteById(int id)
    {
        try
        {
            await _articleRepository.Delete(id);
            return Ok();
        }
        catch (DatabaseException e)
        {
            Console.WriteLine(e);
            return Problem(e.Message);
        }
        
    }

    [HttpPut]
    public async Task<IActionResult> UpdateById(int id, ArticleRequest articleRequest)
    {
        try
        {
            var article = await _articleRepository.GetById(id);
            article.Title = articleRequest.Title;
            article.Body = articleRequest.Body;
            await _articleRepository.Update(article);
            return Ok();
        }
        catch (DatabaseException e)
        {
            Console.WriteLine(e);
            return Problem(e.Message);
        }
        
    }
}