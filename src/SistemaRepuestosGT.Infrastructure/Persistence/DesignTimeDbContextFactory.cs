using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SistemaRepuestosGT.Infrastructure.Data;

namespace SistemaRepuestosGT.Infrastructure.Persistence;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

        optionsBuilder.UseSqlServer(
            "Server=FUENTES\\SQLEXPRESS;Database=SistemaRepuestosGT;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True");

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}