using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace crudleon.Models.ViewModels
{
    public class UserViewModel
    {
        [Required]
        [EmailAddress]
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Correo Electronico")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name = "Confirmar contraseña")]
        [DataType(DataType.Password)]
        // El mensaje que se vera en @Html.ValidationMessageFor(m => m.ConfirmPassword)
        [Compare("Password", ErrorMessage = "Las contraseñas no son iguales")] //www.aspsnippets.com/Articles/Compare-Model-Properties-using-Data-Annotations-in-ASPNet-MVC-Razor.aspx
        public string ConfirmPassword { get; set; }

        [Required]
        public int Edad { get; set; }
    }
}