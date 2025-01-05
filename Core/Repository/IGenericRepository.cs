namespace GenericAPI.Core.Repository;
using Entities;

public interface IGenericRepository
{
    Task<IEnumerable<Pessoa?>> GetAllUsersAsync();
    Task<Pessoa?> GetUserByIdAsync(int id);
    Task AddUserAsync(Pessoa pessoa);
    Task<Pessoa?> UpdateUserAsync(Pessoa pessoa);
    Task<bool> DeleteUserAsync(int id);
}