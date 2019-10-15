using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityTemplate.ViewModels
{
    public class RegistrarseViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Contrasenia { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Contraseña")]
        [Compare("Contrasenia", ErrorMessage = "La contraseña y la contraseña de confirmación no coinciden")]
        public string ConfirmarContrasenia { get; set; }
    }
}
