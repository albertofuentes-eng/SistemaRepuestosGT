using Microsoft.EntityFrameworkCore;
using SistemaRepuestosGT.Application.Interfaces.Repositories;
using SistemaRepuestosGT.Domain.Entities;
using SistemaRepuestosGT.Infrastructure.Data;

namespace SistemaRepuestosGT.Infrastructure.Repositories;

public class UsuarioRepository
    : GenericRepository<Usuario>, IUsuarioRepository
{
    public UsuarioRepository(ApplicationDbContext context)
        : base(context)
    {
    }

    public async Task<Usuario?> GetByUserNameAsync(string nombreUsuario)
    {
        return await _context.Usuarios
            .Include(x => x.Rol)
            .FirstOrDefaultAsync(x => x.NombreUsuario == nombreUsuario);
    }

    public async Task<Usuario?> LoginAsync(string nombreUsuario, string passwordHash)
    {
        return await _context.Usuarios
            .Include(x => x.Rol)
            .FirstOrDefaultAsync(x =>
                x.NombreUsuario == nombreUsuario &&
                x.PasswordHash == passwordHash &&
                x.Activo);
    }
}