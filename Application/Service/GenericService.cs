using GenericAPI.Infrastructure.Data;
using GenericAPI.Core.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;


namespace GenericAPI.Application;

public class GenericService : IGenericService
{
    private readonly BaseContext _baseContext;

    public GenericService(BaseContext baseContext)
    {
        _baseContext = baseContext;
    }
    public async Task<IEnumerable<Pessoa>> GetAllUsersAsync()
    {
        return await _baseContext.Pessoas.ToListAsync();
    }

    public async Task<Pessoa?> GetUserByIdAsync(int id)
    {
        return await _baseContext.Pessoas.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task AddUserAsync(int idPessoa, string? name, string? email)
    {
        // if (pessoa == null) throw new ArgumentNullException(nameof(pessoa));
        var pessoa = new Pessoa
        {
            IdPessoa = idPessoa,
            Name = name,
            Email = email,
            CreatedAt = DateTime.UtcNow
        };

    await _baseContext.Pessoas.AddAsync(pessoa);
    await _baseContext.SaveChangesAsync();
    }

    public async Task<Pessoa?> UpdateUserAsync(int id, int idPessoa, string? name, string? email)
    {
        var pessoa = await _baseContext.Pessoas.FindAsync(id);
        
        if (pessoa == null)
        {
            return null; 
        }

        pessoa.IdPessoa = idPessoa;
        pessoa.Name = name;
        pessoa.Email = email;    
            
        _baseContext.Pessoas.Update(pessoa);
        await _baseContext.SaveChangesAsync();

        return pessoa;
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        var pessoa = await _baseContext.Pessoas.FindAsync(id);
        if (pessoa == null)
        {
            return false;
        }
        _baseContext.Pessoas.Remove(pessoa);
        await _baseContext.SaveChangesAsync();
        
        return true;
    }
}