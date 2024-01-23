using Articles.API.Exceptions;
using Articles.API.Repository.User;
using Articles.Contract.User;
using Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Articles.API.Controllers;
[ApiController]
[Route("user")]
public class UserController : ControllerBase, ICRUD<UserRequest>
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        try
        {
            return Ok(await _userRepository.GetAll().ToListAsync());
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
            return Ok(await _userRepository.GetById(id));
        }
        catch (DatabaseException e)
        {
            Console.WriteLine(e);
            return Problem(e.Message);
        }
    }
    [HttpPost]
    public async Task<IActionResult> Add(UserRequest userRequest)
    {
        try
        {
            var user = new User()
            {
                Password = userRequest.Password,
                Username = userRequest.Username
            };
            await _userRepository.Create(user);
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
            await _userRepository.Delete(id);
            return Ok();
        }
        catch (DatabaseException e)
        {
            Console.WriteLine(e);
            return Problem(e.Message);
        }
        
    }

    [HttpPut]
    public async Task<IActionResult> UpdateById(int id, UserRequest userRequest)
    {
        try
        {
            var user = await _userRepository.GetById(id);
            user.Username = userRequest.Username;
            user.Password = userRequest.Password;
            await _userRepository.Update(user);
            return Ok();
        }
        catch (DatabaseException e)
        {
            Console.WriteLine(e);
            return Problem(e.Message);
        }
        
    }
    
}