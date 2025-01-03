using GenericAPI.Core.Entities;

namespace GenericAPI.Application;

public interface IGenericService
{
    Task<IEnumerable<Pessoa>> GetAllUsersAsync();
    Task<Pessoa?> GetUserByIdAsync(int id);
    Task AddUserAsync(Pessoa? pessoa);
    Task UpdateUserAsync(Pessoa? pessoa);
    Task DeleteUserAsync(int id);
}