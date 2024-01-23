using Articles.Contract.User;
using Microsoft.AspNetCore.Mvc;

namespace Articles.API.Controllers;

public interface ICRUD<in T>
{
    public Task<IActionResult> GetList();
    public Task<IActionResult> GetById(int id);
    public Task<IActionResult> Add(T request);
    public Task<IActionResult> DeleteById(int id);
    public Task<IActionResult> UpdateById(int id, T request);
}