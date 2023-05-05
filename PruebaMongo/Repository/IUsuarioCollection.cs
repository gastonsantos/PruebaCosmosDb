using PruebaMongo.Models;

namespace PruebaMongo.Repository
{
    public interface IUsuarioCollection
    {
        public Usuario GetUserByNameAndPass(string name, string pass);
        public void InsertUsuario(Usuario usuario);


    }
}
