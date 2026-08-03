namespace SistemaRepuestosGT.Domain.Entities;

public class Empresa : BaseEntity
{
    public int EmpresaId { get; set; }

    public string Nombre { get; set; } = string.Empty;

    public string? NombreComercial { get; set; }

    public string Propietario { get; set; } = string.Empty;

    public string? NIT { get; set; }

    public string Direccion { get; set; } = string.Empty;

    public string Telefono { get; set; } = string.Empty;

    public string? Correo { get; set; }

    public string? Logo { get; set; }
}