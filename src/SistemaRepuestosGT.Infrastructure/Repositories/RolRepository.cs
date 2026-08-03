using Microsoft.EntityFrameworkCore;
using SistemaRepuestosGT.Application.Interfaces.Repositories;
using SistemaRepuestosGT.Domain.Entities;
using SistemaRepuestosGT.Infrastructure.Data;

namespace SistemaRepuestosGT.Infrastructure.Repositories;

public class RolRepository
    : GenericRepository<Rol>, IRolRepository
{
    public RolRepository(ApplicationDbContext context)
        : base(context)
    {
    }

    public async Task<Rol?> GetByNameAsync(string nombre)
    {
        return await _context.Roles
            .FirstOrDefaultAsync(x => x.Nombre == nombre);
    }
}