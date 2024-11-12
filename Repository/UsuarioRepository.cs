using Microsoft.EntityFrameworkCore;
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

        public async Task<Usuario> AddUsuario(Usuario usuario)
        {
            var result = await dbContext.Usuarios.AddAsync(usuario);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public Task<Usuario> DeleteUsuario(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            return await dbContext.Usuarios.ToListAsync();
        }

        public Task<Usuario> UpdateUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
