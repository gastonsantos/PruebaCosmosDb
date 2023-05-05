using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace PruebaMongo.Models
{
    public class Usuario
    {
        [BsonId]
        public ObjectId Id { get; set; } //para manejar el id en Mongo/ es autoIncremental

        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Apellido es requerido")]
        public string Apellido { get; set; } = string.Empty;


        [Required(ErrorMessage = "La Contraseña es requerida")]
        public string Contraseña { get; set; } = string.Empty;
    }
}
