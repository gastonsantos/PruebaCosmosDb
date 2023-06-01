using MongoDB.Bson;

namespace PruebaMongo.Models
{
    public class Visit
    {
        public ObjectId Id { get; set; }

        public string Fecha { get; set; }

        public string RangoHorario { get; set; }

        public string Email { get; set; }

        public string Nombre { get; set; }

        public string Telefono { get; set; }



    }
}
