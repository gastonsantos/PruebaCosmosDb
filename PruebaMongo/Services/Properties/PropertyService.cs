﻿using PruebaMongo.Repository;
using PruebaMongo.Models;

namespace PruebaMongo.Services.Properties;

public class PropertyService : IPropertyService
{
    private readonly IPropertyRepository _propertyRepository;

    public PropertyService(IPropertyRepository propertyRepository)
    {
        this._propertyRepository = propertyRepository;
    }
    public void Save(Property property)
    {
        this._propertyRepository.InsertPropiedad(property);
    }

    public Property getPropertyById(string id)
    {

        return this._propertyRepository.GetPropiedadByID(id);
    }

    public IList<Property> GetAll()
    {
        return this._propertyRepository.GetAllPropiedades();
    }

    public IList<Property> RecommendProperties(User user)
    {
        var properties = this.GetAll();
        var nonSelectableProperties = user.FavouritesProperties.Concat(user.ReservedProperties);

        return properties.Except(nonSelectableProperties)
            .Take(5)
            .ToList();
    }
}