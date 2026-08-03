using System.ComponentModel.DataAnnotations;

namespace SistemaRepuestosGT.Web.ViewModels.Account;

public class LoginViewModel
{
    [Required(ErrorMessage = "Ingrese el usuario.")]
    [Display(Name = "Usuario")]
    public string NombreUsuario { get; set; } = string.Empty;

    [Required(ErrorMessage = "Ingrese la contraseña.")]
    [DataType(DataType.Password)]
    [Display(Name = "Contraseña")]
    public string Password { get; set; } = string.Empty;
}