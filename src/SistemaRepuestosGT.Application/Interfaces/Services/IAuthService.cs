using SistemaRepuestosGT.Application.DTOs;

namespace SistemaRepuestosGT.Application.Interfaces.Services;

public interface IAuthService
{
    Task<LoginResponseDto> LoginAsync(LoginRequestDto request);
}