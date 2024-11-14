using Microsoft.EntityFrameworkCore;
using Solar_Tracker.SolarTrackerAPI.Data;
using Solar_Tracker.SolarTrackerAPI.Models;
using Solar_Tracker.SolarTrackerAPI.Repository.Interface;
using System.Numerics;

namespace Solar_Tracker.SolarTrackerAPI.Repository
{
    public class RegistroEnergiaRepository : IRegistroEnergiaRepository
    {
        private readonly dbContext dbContext;

        public RegistroEnergiaRepository(dbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<RegistroEnergia> AddRegistro(RegistroEnergia registro)
        {
            var result = await dbContext.RegistroEnergias.AddAsync(registro);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<RegistroEnergia> GetRegistro(int eneid)
        {
            return await dbContext.RegistroEnergias.FirstOrDefaultAsync(x => x.idRegistroEnergia == eneid);
        }

        public async Task<IEnumerable<RegistroEnergia>> GetRegistros()
        {
            return await dbContext.RegistroEnergias.ToListAsync();
        }



        public async Task<RegistroEnergia> UpdateRegistro(RegistroEnergia registro)
        {
            var result = await dbContext.RegistroEnergias.FirstOrDefaultAsync(x => x.IdPlacaSolar == registro.IdPlacaSolar);

            if (result != null)
            {
                result.IdPlacaSolar = registro.IdPlacaSolar;
                result.Temperatura = registro.Temperatura;
                result.Geracao = registro.Geracao;
                await dbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }


    }
}
