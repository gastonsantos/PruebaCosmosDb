using MongoFramework;

namespace PruebaMongo.Models
{
    public class Ubicacion
    {
        public string Provincia { get; set; }

        public string Localidad { get; set; }

        public string Calle { get; set; }

        public int Numero { get; set; }

        public string CodigoPostal { get; set; }

        public string? Departamento { get; set; }

        public string? Piso { get; set; }


    }
}
