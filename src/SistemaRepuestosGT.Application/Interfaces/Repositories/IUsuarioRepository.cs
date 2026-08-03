using SistemaRepuestosGT.Domain.Entities;

namespace SistemaRepuestosGT.Application.Interfaces.Repositories;

public interface IUsuarioRepository : IGenericRepository<Usuario>
{
    Task<Usuario?> GetByUserNameAsync(string nombreUsuario);

    Task<Usuario?> LoginAsync(string nombreUsuario, string passwordHash);
}