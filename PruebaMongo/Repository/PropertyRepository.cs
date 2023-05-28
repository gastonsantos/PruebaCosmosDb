using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using PruebaMongo.Models;
using System.Collections.Generic;

namespace PruebaMongo.Repository;

public class PropertyRepository : IPropertyRepository
{
    private readonly AppContext _context;

    public PropertyRepository()
    {
        _context = new(ConnectionFactory.GetConnection());
    }

    public List<Property> GetAllPropiedades()
    {
        var properties = _context.Propiedades.AsQueryable().ToList();//expresiones LINQ

        return properties; 
    }

    public Property GetPropiedadByID(string id)
    {
        var propiedad = _context.Propiedades.FirstOrDefault(Prop => Prop.Id == new ObjectId(id));
        _context.SaveChanges();

        return propiedad;
    }

    public void InsertPropiedad(Property propiedad)
    {
        _context.Propiedades.Add(propiedad);
        _context.SaveChanges();
    }

    public List<string> getAllState()
    {
        var states = _context.Propiedades.
            Select(p => p.Ubicacion.Provincia).
            Distinct().
            ToList();

        _context.SaveChanges();
        return states;
    }
    public List<string> getAllLocation()
    {
        var states = _context.Propiedades
            .Select(p => p.Ubicacion.Localidad)
            .Distinct()
            .ToList();
        _context.SaveChanges();
        return states;
    }

    public List<Property> searchProperty(string state, string location, string operation)
    {
        IQueryable<Property> query = _context.Propiedades;

        if (!string.IsNullOrEmpty(state))
        {
            query = query.Where(p => p.Ubicacion.Provincia == state);
        }

        if (!string.IsNullOrEmpty(location))
        {
            query = query.Where(p => p.Ubicacion.Localidad == location);
        }

        if (!string.IsNullOrEmpty(operation))
        {
            query = query.Where(p => p.Operacion == operation);
        }

        List<Property> properties = query.ToList();

        return properties;
    }




}
