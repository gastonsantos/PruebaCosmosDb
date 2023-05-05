using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using System;

namespace PruebaMongo.Models
{
    public class Product 
    {
        [BsonId]
        public ObjectId Id { get; set; } //para manejar el id en Mongo/ es autoIncremental

        [Required(ErrorMessage = "El nombre es requerido")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Stock es requerido")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "La Fecha es requerida")]
        public DateOnly? ExpiryDate { get; set; }

        public string Category { get; set; } = string.Empty;



    }
}
