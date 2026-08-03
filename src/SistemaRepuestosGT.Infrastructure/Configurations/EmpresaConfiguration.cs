using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaRepuestosGT.Domain.Entities;

namespace SistemaRepuestosGT.Infrastructure.Configurations;

public class EmpresaConfiguration : IEntityTypeConfiguration<Empresa>
{
    public void Configure(EntityTypeBuilder<Empresa> builder)
    {
        builder.HasKey(x => x.EmpresaId);

        builder.Property(x => x.Nombre)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(x => x.NombreComercial)
            .HasMaxLength(150);

        builder.Property(x => x.Propietario)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(x => x.NIT)
            .HasMaxLength(20);

        builder.Property(x => x.Direccion)
            .HasMaxLength(250);

        builder.Property(x => x.Telefono)
            .HasMaxLength(25);

        builder.Property(x => x.Correo)
            .HasMaxLength(150);

        builder.Property(x => x.Logo)
            .HasMaxLength(250);
    }
}