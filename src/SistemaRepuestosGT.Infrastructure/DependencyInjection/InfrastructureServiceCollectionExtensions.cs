using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaRepuestosGT.Application.Interfaces.Repositories;
using SistemaRepuestosGT.Infrastructure.Data;
using SistemaRepuestosGT.Infrastructure.Repositories;
using SistemaRepuestosGT.Application.Interfaces.Services;
using SistemaRepuestosGT.Infrastructure.Services;

namespace SistemaRepuestosGT.Infrastructure.DependencyInjection;

public static class InfrastructureServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IUsuarioRepository, UsuarioRepository>();

services.AddScoped<IRolRepository, RolRepository>();

services.AddScoped<IEmpresaRepository, EmpresaRepository>();

services.AddScoped<IAuthService, AuthService>();

        return services;
    }
}