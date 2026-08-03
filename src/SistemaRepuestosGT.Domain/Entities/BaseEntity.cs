namespace SistemaRepuestosGT.Domain.Entities;

public abstract class BaseEntity
{
    public bool Activo { get; set; } = true;

    public DateTime FechaCreacion { get; set; } = DateTime.Now;

    public DateTime? FechaActualizacion { get; set; }
}