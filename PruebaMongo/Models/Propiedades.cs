using MongoDB.Bson;

namespace PruebaMongo.Models
{
    public class Propiedades
    {

        public ObjectId Id { get; set; }

        public string Titulo { get; set; }

        public string Descripcion { get; set; }

        public string Ubicacion { get; set; }

        public decimal Precio { get; set; }

        public int MetrosCuadrados { get; set; }

        public int Habitaciones { get; set; }

        public int Banos { get; set; }

        public bool Garaje { get; set; }

        public List<string> Amenidades { get; set; }

        public string Imagen { get; set; }

        public Agente Agente { get; set; }
    }
}
