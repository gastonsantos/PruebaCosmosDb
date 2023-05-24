﻿using PruebaMongo.Models;

namespace PruebaMongo.Services;

public interface IPropertyService
{
    IList<Property> GetAll();

    IList<Property> RecommendProperties();

    void BookDateToVisit(DateTime date);

    void Save(Property property);
}
