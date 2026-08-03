using Microsoft.EntityFrameworkCore;
using SistemaRepuestosGT.Domain.Entities;
using SistemaRepuestosGT.Infrastructure.Data;
using SistemaRepuestosGT.Infrastructure.Helpers;

namespace SistemaRepuestosGT.Infrastructure.Seed;

public static class DbInitializer
{
    public static async Task SeedAsync(ApplicationDbContext context)
{
    await context.Database.MigrateAsync();

    if (!context.Roles.Any())
    {
        var rol = new Rol
        {
            Nombre = "Administrador",
            Descripcion = "Acceso total al sistema"
        };

        context.Roles.Add(rol);
        await context.SaveChangesAsync();
    }

    if (!context.Empresas.Any())
    {
        var empresa = new Empresa
        {
            Nombre = "Sistema Repuestos GT",
            NombreComercial = "Sistema Repuestos GT",
            Propietario = "Administrador",
            Direccion = "Guatemala",
            Telefono = "00000000",
            Correo = "admin@repuestosgt.com"
        };

        context.Empresas.Add(empresa);
        await context.SaveChangesAsync();
    }

    if (!context.Usuarios.Any())
    {
        var rolAdmin = await context.Roles.FirstAsync();

        var usuario = new Usuario
        {
            Nombre = "Administrador",
            Apellido = "General",
            NombreUsuario = "admin",
            Correo = "admin@repuestosgt.com",
            PasswordHash = PasswordHelper.Hash("Admin123"),
            RolId = rolAdmin.RolId,
            Activo = true
        };

        context.Usuarios.Add(usuario);

        await context.SaveChangesAsync();
    }
}
}