using PruebaMongo.Models;
using PruebaMongo.Repository;

namespace PruebaMongo.Services.Agents;

public class AgentService: IAgentService
{
    private readonly IAgentRepository _agentRepository;

    public AgentService(IAgentRepository agentRepository)
    {
        this._agentRepository = agentRepository;
    }
    public IList<Agente> GetAllAgents()
    {
        return this._agentRepository.GetAllAgents();
    }

    public Agente GetAgente(string id)
    {
        return this._agentRepository.GetAgentByID(id);
    }

}    
