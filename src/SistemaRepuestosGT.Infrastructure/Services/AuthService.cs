using SistemaRepuestosGT.Application.DTOs;
using SistemaRepuestosGT.Application.Interfaces.Repositories;
using SistemaRepuestosGT.Application.Interfaces.Services;

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

        // Aquí luego validaremos el hash de la contraseña

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