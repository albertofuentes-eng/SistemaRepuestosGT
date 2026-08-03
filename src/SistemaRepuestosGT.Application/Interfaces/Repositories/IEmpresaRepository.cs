using SistemaRepuestosGT.Domain.Entities;

namespace SistemaRepuestosGT.Application.Interfaces.Repositories;

public interface IEmpresaRepository : IGenericRepository<Empresa>
{
    Task<Empresa?> GetEmpresaPrincipalAsync();
}