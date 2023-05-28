using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace PruebaMongo.Models;

[Table("Message")]
public class Contacto

{
    [Required(ErrorMessage = "El Nombre es requerido")]
    public string Nombre { get; set; }

    [Required(ErrorMessage = "El Email es requerido")] 
    [EmailAddress(ErrorMessage = "Formato Incorrecto")]    
    public string Email { get; set; }

    [Required(ErrorMessage = "El Mensaje es requerido")]
    public string Mensaje { get; set; }

}
