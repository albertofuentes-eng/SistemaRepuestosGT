using SistemaRepuestosGT.Application.DTOs;
using SistemaRepuestosGT.Application.Interfaces.Repositories;
using SistemaRepuestosGT.Application.Interfaces.Services;
using SistemaRepuestosGT.Infrastructure.Helpers;

namespace SistemaRepuestosGT.Infrastructure.Services;

public class AuthService : IAuthService
{
    private readonly IUsuarioRepository _usuarioRepository;

    public AuthService(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<LoginResponseDto> LoginAsync(LoginRequestDto request)
{
    var usuario = await _usuarioRepository.GetByUserNameAsync(request.NombreUsuario);

    if (usuario == null)
    {
        return new LoginResponseDto
        {
            Success = false,
            Message = "Usuario no encontrado."
        };
    }

    // Validación temporal de contraseña
    var passwordHash = PasswordHelper.Hash(request.Password);

if (usuario.PasswordHash != passwordHash)
{
    return new LoginResponseDto
    {
        Success = false,
        Message = "Usuario o contraseña incorrectos."
    };
}

    return new LoginResponseDto
    {
        Success = true,
        UsuarioId = usuario.UsuarioId,
        NombreCompleto = $"{usuario.Nombre} {usuario.Apellido}",
        Rol = usuario.Rol.Nombre,
        Message = "Login correcto."
    };
}
}