using GenericAPI.Application;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using GenericAPI.Core.Entities;

namespace GenericAPI.API.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]

public class GenericController : ControllerBase
{
    private readonly IGenericService _genericService;

    public GenericController(IGenericService genericService)
    {
        _genericService = genericService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Pessoa>>> GetTodasPessoas()
    {
        var pessoas = await _genericService.GetAllUsersAsync(); 
        return Ok(pessoas);
    }

    [HttpGet]
    public async Task<ActionResult<Pessoa>> GetPessoaById(int id)
    {
        var pessoa = await _genericService.GetUserByIdAsync(id);
        if (pessoa == null)
        {
            return NotFound("Sem usuário com esse ID");
        }

        return (pessoa);
    }
    
    [HttpPost]
    public async Task<ActionResult<Pessoa>> AdicionarPessoar([FromBody] Pessoa pessoa)
    {
        await _genericService.AddUserAsync(pessoa.IdPessoa, pessoa.Name, pessoa.Email);
        return Content("Usuário Adicionado com Sucesso");
    }

    [HttpPut]
    public async Task<IActionResult> UpdatePessoa(int id, [FromBody] Pessoa pessoa)
    {
        var updatedUser = await _genericService.UpdateUserAsync(id, pessoa.IdPessoa, pessoa.Name, pessoa.Email);

        if (updatedUser == null)
        {
            return NotFound($"The ID: {id} was not found.");
        }

        return Ok(updatedUser);
    }

    [HttpDelete]
    public async Task<IActionResult> DeletarPessoa(int id)
    {
        var isDeleted = await _genericService.DeleteUserAsync(id);

        if (!isDeleted)
        {
            return NotFound($"User with ID {id} not found.");
        }

        return NoContent();
    }
}