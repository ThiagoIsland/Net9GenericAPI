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

}