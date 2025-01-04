using GenericAPI.Infrastructure.Data;
using GenericAPI.Core.Entities;
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

    public async Task UpdateUserAsync(Pessoa? pessoa)
    {
        if (pessoa == null) throw new ArgumentNullException(nameof(pessoa));
        _baseContext.Pessoas.Update(pessoa);
        await _baseContext.SaveChangesAsync();
    }

    public async Task DeleteUserAsync(int id)
    {
        var user = await _baseContext.Pessoas.FindAsync(id);
        if (user != null)
        {
            _baseContext.Pessoas.Remove(user);
            await _baseContext.SaveChangesAsync();
        }
    }
}