using Microsoft.AspNetCore.Mvc;
using SistemaRepuestosGT.Application.Interfaces.Services;
using SistemaRepuestosGT.Web.ViewModels.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using SistemaRepuestosGT.Application.DTOs;

namespace SistemaRepuestosGT.Web.Controllers;

public class AccountController : Controller
{
    private readonly IAuthService _authService;

    public AccountController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var response = await _authService.LoginAsync(
            new LoginRequestDto
            {
                NombreUsuario = model.NombreUsuario,
                Password = model.Password
            });

        if (!response.Success)
        {
            ModelState.AddModelError("", response.Message);
            return View(model);
        }

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, response.UsuarioId.ToString()),
            new Claim(ClaimTypes.Name, response.NombreCompleto),
            new Claim(ClaimTypes.Role, response.Rol)
        };

        var identity = new ClaimsIdentity(
            claims,
            CookieAuthenticationDefaults.AuthenticationScheme);

        var principal = new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            principal);

        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);

        return RedirectToAction(nameof(Login));
    }
}