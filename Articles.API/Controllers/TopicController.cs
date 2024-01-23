using Articles.API.Exceptions;
using Articles.API.Repository.Topic;
using Articles.Contract.Topic;
using Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Articles.API.Controllers;
[ApiController]
[Route("topic")]
public class TopicController : ControllerBase, ICRUD<TopicRequest>
{
    private readonly ITopicRepository _topicRepository;

    public TopicController(ITopicRepository topicRepository)
    {
        _topicRepository = topicRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        try
        {
            return Ok(await _topicRepository.GetAll().ToListAsync());
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
            return Ok(await _topicRepository.GetById(id));
        }
        catch (DatabaseException e)
        {
            Console.WriteLine(e);
            return Problem(e.Message);
        }
        
    }
    [HttpPost]
    public async Task<IActionResult> Add(TopicRequest topicRequest)
    {
        try
        {
            var topic = new Topic()
            {
                Name = topicRequest.Name,
                Created = DateTime.Now
            };
            await _topicRepository.Create(topic);
            return Ok();
        }
        catch (Exception e)
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
            await _topicRepository.Delete(id);
            return Ok();
        }
        catch (DatabaseException e)
        {
            Console.WriteLine(e);
            return Problem(e.Message);
        }
        
    }

    [HttpPut]
    public async Task<IActionResult> UpdateById(int id, TopicRequest topicRequest)
    {
        try
        {
            var topic = await _topicRepository.GetById(id);
            topic.Name = topicRequest.Name;
            await _topicRepository.Update(topic);
            return Ok();
        }
        catch (DatabaseException e)
        {
            Console.WriteLine(e);
            return Problem(e.Message);
        }
        
    }
}