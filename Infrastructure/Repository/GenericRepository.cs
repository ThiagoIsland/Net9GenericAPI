using GenericAPI.Core.Repository;
using GenericAPI.Core.Entities;
using GenericAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace GenericAPI.Infrastructure.Repository;

public class GenericRepository : IGenericRepository
{
    private readonly BaseContext _baseContext;

    public GenericRepository(BaseContext baseContext)
    {
        _baseContext = baseContext;
    }
    
    public async Task<IEnumerable<Pessoa?>> GetAllUsersAsync()
    {
        return await _baseContext.Pessoas.ToListAsync();
    }

    public async Task<Pessoa?> GetUserByIdAsync(int id)
    {
        return await _baseContext.Pessoas.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task AddUserAsync(Pessoa pessoa)
    {
        await _baseContext.Pessoas.AddAsync(pessoa);
        await _baseContext.SaveChangesAsync();
    }

    public async Task<Pessoa?> UpdateUserAsync(Pessoa pessoa)
    {
        var pessoaExistente = await _baseContext.Pessoas.FindAsync(pessoa.Id);
        if (pessoaExistente == null) return null;

        pessoaExistente.Name = pessoa.Name;
        pessoaExistente.Email = pessoa.Email;
        pessoaExistente.IdPessoa = pessoa.IdPessoa;
        
        _baseContext.Pessoas.Update(pessoaExistente);
        await _baseContext.SaveChangesAsync();

        return pessoaExistente;
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