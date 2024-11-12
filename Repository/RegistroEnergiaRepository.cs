using Solar_Tracker.Data;
using Solar_Tracker.Models;
using Solar_Tracker.Repository.Interface;

namespace Solar_Tracker.Repository
{
    public class RegistroEnergiaRepository : IRegistroEnergiaRepository
    {
        private readonly dbContext dbContext;

        public RegistroEnergiaRepository(dbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<RegistroEnergia> AddRegistro(RegistroEnergia registro)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RegistroEnergia>> GetRegistros()
        {
            throw new NotImplementedException();
        }

        public Task<RegistroEnergia> UpdateRegistro(RegistroEnergia registro)
        {
            throw new NotImplementedException();
        }
    }
}
