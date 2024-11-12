using Solar_Tracker.Models;

namespace Solar_Tracker.Repository.Interface
{
    public interface IRegistroEnergiaRepository
    {
        Task<IEnumerable<RegistroEnergia>> GetRegistros();
        Task<RegistroEnergia> AddRegistro(RegistroEnergia registro);
        Task<RegistroEnergia> UpdateRegistro(RegistroEnergia registro);

    }
}
