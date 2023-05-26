using MongoDB.Bson;
using MongoFramework;
using MongoFramework.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaMongo.Models;

[Table("MyCustomPoperty")]
public class Property
{
    
    public ObjectId Id { get; set; }

    [Column("MappedTitulo")]
    public string Titulo { get; set; }

    public string Descripcion { get; set; }

    
    public Ubicacion Ubicacion { get; set; }

    public decimal Precio { get; set; }

    public int MetrosCuadrados { get; set; }

    public int Habitaciones { get; set; }

    public int Banos { get; set; }

    public bool Garaje { get; set; }

    public List<string> Amenidades { get; set; }

    public string? Imagen { get; set; }

    public Agente Agente { get; set; }
}
