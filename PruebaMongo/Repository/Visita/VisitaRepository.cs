using MongoDB.Bson;
using MongoDB.Driver;
using PruebaMongo.Models;

using Microsoft.AspNetCore.Mvc;
using MongoFramework.Linq;

namespace PruebaMongo.Repository.Visita;

public class VisitaRepository : IVisitaRepository
{

    private readonly AppContext _context;

    public VisitaRepository()
    {
        _context = new(ConnectionFactory.GetConnection());
    }


    public void SendVisita(Visit visita)
    {
        _context.Visita.Add(visita);
        _context.SaveChanges();
    }

}
