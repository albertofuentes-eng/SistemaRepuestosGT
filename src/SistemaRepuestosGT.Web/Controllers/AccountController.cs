using Microsoft.AspNetCore.Mvc;
using SistemaRepuestosGT.Application.Interfaces.Services;
using SistemaRepuestosGT.Web.ViewModels.Account;

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

        // Aquí conectaremos el servicio de autenticación
        // en el siguiente bloque.

        return RedirectToAction("Index", "Home");
    }
}