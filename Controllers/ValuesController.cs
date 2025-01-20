using Microsoft.AspNetCore.Mvc;
using GenericAPI.Application;
using GenericAPI.Infrastructure.Data;

namespace GenericAPI.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]

public class ValuesController : ControllerBase
{
    private readonly BaseContext _context;
    
    public ValuesController(BaseContext baseContext)
    {
        _context = baseContext;
    }
    
    // GET: api/values
    [HttpGet]
    public IActionResult GetValues()
    {
        return Content("Teste de API");
    }
    
    
    [HttpGet("teste")]
    public IActionResult GetBancoTest()
    {
        var test = _context.Database.CanConnect();
        return Content($"Conexão com o banco: {test}");
    }
}