using GenericAPI.Application;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using GenericAPI.Core.Entities;

namespace GenericAPI.API.Controllers;

[ApiController]
[Route("api/Controller")]

public class GenericController : ControllerBase
{
    private readonly IGenericService _genericService;

    public GenericController(IGenericService genericService)
    {
        _genericService = genericService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Pessoa>>> GetUsers()
    {
        return Ok(_genericService.GetAllUsersAsync);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Pessoa>> GetUser(int id)
    {
        var pessoa = await _genericService.GetUserByIdAsync(id);
        if (pessoa == null)
        {
            return NotFound("Sem usuário com esse ID");
        }
        return (pessoa);

    }
}