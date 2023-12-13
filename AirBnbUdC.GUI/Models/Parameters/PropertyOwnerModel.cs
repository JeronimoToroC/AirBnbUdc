using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AirBnbUdC.GUI.Models.Parameters
{
    public class PropertyOwnerModel
    {
        [DisplayName("PropertyOwner")]
        public long Id { get; set; }

        [DisplayName("Nombre")]
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(50, ErrorMessage = "El nombre debe tener entre 3 y 50 caracteres", MinimumLength = 3)]
        public string FirstName { get; set; }

        [DisplayName("Apellido")]
        [Required(ErrorMessage = "Los apellidos son requeridos")]
        [StringLength(50, ErrorMessage = "Los apellidos debe tener entre 3 y 50 caracteres", MinimumLength = 3)]
        public string FamilyName { get; set; }

        [DisplayName("Correo")]
        [Required(ErrorMessage = "El correo es requerido")]
        public string Email {  get; set; }

        [DisplayName("Celular")]
        [Required(ErrorMessage = "El numero de celular es requerido")]
        public string CellPhone { get; set; }

        [DisplayName("Imagen")]
        public string Photo { get; set; }
    }
}