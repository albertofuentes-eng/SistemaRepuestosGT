using Microsoft.EntityFrameworkCore;
using SistemaRepuestosGT.Application.Interfaces.Repositories;
using SistemaRepuestosGT.Domain.Entities;
using SistemaRepuestosGT.Infrastructure.Data;

namespace SistemaRepuestosGT.Infrastructure.Repositories;

public class EmpresaRepository
    : GenericRepository<Empresa>, IEmpresaRepository
{
    public EmpresaRepository(ApplicationDbContext context)
        : base(context)
    {
    }

    public async Task<Empresa?> GetEmpresaPrincipalAsync()
    {
        return await _context.Empresas.FirstOrDefaultAsync();
    }
}