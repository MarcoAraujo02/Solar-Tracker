using Solar_Tracker.Models;

namespace Solar_Tracker.Repository.Interface
{
    public interface IUsuarioRepository
    {

        Task<IEnumerable<Usuario>> GetUsuarios();
        Task<Usuario> AddUsuario(Usuario usuario);
        Task<Usuario> UpdateUsuario(Usuario usuario);
        Task<Usuario> DeleteUsuario(int id);
    }
}
