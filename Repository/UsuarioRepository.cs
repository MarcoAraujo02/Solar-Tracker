using Solar_Tracker.Data;
using Solar_Tracker.Models;
using Solar_Tracker.Repository.Interface;

namespace Solar_Tracker.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly dbContext dbContext;

        public UsuarioRepository(dbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<Usuario> AddUsuario()
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> DeleteUsuario(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Usuario>> GetUsuarios()
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> UpdateUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
