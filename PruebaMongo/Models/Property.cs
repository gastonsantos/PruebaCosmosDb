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

    public string Operacion { get; set; }
    public Ubicacion Ubicacion { get; set; }

    public decimal Precio { get; set; }

    public int MetrosCuadrados { get; set; }

    public int Habitaciones { get; set; }

    public int Banos { get; set; }

    public bool Garaje { get; set; }

    public List<string> Amenidades { get; set; }

    public string? Imagen { get; set; }

    public Agente Agente { get; set; }


    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;

        Property other = (Property)obj;

        return Id.Equals(other.Id);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}
