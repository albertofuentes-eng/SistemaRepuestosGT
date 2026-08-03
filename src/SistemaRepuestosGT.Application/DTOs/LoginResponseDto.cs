namespace SistemaRepuestosGT.Application.DTOs;

public class LoginResponseDto
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public int UsuarioId { get; set; }

    public string NombreCompleto { get; set; } = string.Empty;

    public string Rol { get; set; } = string.Empty;
}