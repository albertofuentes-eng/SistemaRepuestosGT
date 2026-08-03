using SistemaRepuestosGT.Domain.Entities;

namespace SistemaRepuestosGT.Application.Interfaces.Repositories;

public interface IRolRepository : IGenericRepository<Rol>
{
    Task<Rol?> GetByNameAsync(string nombre);
}