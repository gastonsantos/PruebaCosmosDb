using MongoFramework;
using MongoFramework.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaMongo.Models
{

    [Table("Direccion")]
    public class Ubicacion
    {

        [Index("Provincia", IndexSortOrder.Ascending)]
        public string Provincia { get; set; }

        [Index("Localidad", IndexSortOrder.Ascending)]
        public string Localidad { get; set; }

        public string Calle { get; set; }

        public int Numero { get; set; }

        public string CodigoPostal { get; set; }

        public string? Departamento { get; set; }

        public string? Piso { get; set; }


    }
}
