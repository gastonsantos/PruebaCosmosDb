using PruebaMongo.Models;

namespace PruebaMongo.Services.Agents;

public interface  IAgentService
{
    public IList<Agente> GetAllAgents();
    public Agente GetAgente(string id);
}
