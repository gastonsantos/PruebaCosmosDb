using PruebaMongo.Models;

namespace PruebaMongo.Repository
{
   public  interface IAgentRepository
    {
        public List<Agente> GetAllAgents();

        public Agente GetAgentByID(string id);
    }
}
