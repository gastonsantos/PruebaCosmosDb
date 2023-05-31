using PruebaMongo.Models;
using PruebaMongo.Repository.Visita;

namespace PruebaMongo.Services.Visita;

public class VisitaService : IVisitaService
{

    private readonly IVisitaRepository _visitaRepository;

    public VisitaService(IVisitaRepository visitaRepository)
    {
        this._visitaRepository = visitaRepository;
    }



    public void SendVisita(Visit visita) {
       this._visitaRepository.SendVisita(visita);

    }









}
