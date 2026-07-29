namespace SistemaRepuestosGT.Web.Models.Entities;

public class Usuario : BaseEntity
{
    public int UsuarioId { get; set; }

    public string Nombre { get; set; } = string.Empty;

    public string Apellido { get; set; } = string.Empty;

    public string NombreUsuario { get; set; } = string.Empty;

    public string? Correo { get; set; }

    public string PasswordHash { get; set; } = string.Empty;

    public DateTime? UltimoAcceso { get; set; }

    public int RolId { get; set; }

    public Rol Rol { get; set; } = null!;
}