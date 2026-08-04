using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaRepuestosGT.Application.Interfaces.Repositories;

namespace SistemaRepuestosGT.Web.Controllers;

[Authorize(Roles = "Administrador")]
public class AdminController : Controller
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IRolRepository _rolRepository;
    private readonly IEmpresaRepository _empresaRepository;

    public AdminController(
        IUsuarioRepository usuarioRepository,
        IRolRepository rolRepository,
        IEmpresaRepository empresaRepository)
    {
        _usuarioRepository = usuarioRepository;
        _rolRepository = rolRepository;
        _empresaRepository = empresaRepository;
    }

    public async Task<IActionResult> Index()
    {
        ViewBag.TotalUsuarios = (await _usuarioRepository.GetAllAsync()).Count();
        ViewBag.TotalRoles = (await _rolRepository.GetAllAsync()).Count();
        ViewBag.TotalEmpresas = (await _empresaRepository.GetAllAsync()).Count();

        return View();
    }
}