using MessagePack;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaMongo.Models;

 
    public class Agente
    {

         
        public ObjectId Id { get; set; }

        public string Nombre { get; set; }

        public string Email { get; set; }

        public string Telefono { get; set; }
    }

