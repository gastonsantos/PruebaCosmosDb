using MongoDB.Bson;
using PruebaMongo.Models;

namespace PruebaMongo.Repository
{
    public class AgentRepository : IAgentRepository
    {
        private AppContext context;

        public AgentRepository()
        {
            Console.Write(ConnectionFactory.GetConnection());
            context = new(ConnectionFactory.GetConnection());
        }

        public List<Agente> GetAllAgents()
        {
            var agents = context.Agentes.AsQueryable().ToList();

            return agents;
        }

        public Agente GetAgentByID(string id)
        {
            var agent = context.Agentes.FirstOrDefault(ag => ag.Id == new ObjectId(id));
            context.SaveChanges();
           

            return agent;
        }


    }
}
