using Microsoft.EntityFrameworkCore;
using Solar_Tracker.SolarTrackerAPI.Data;
using Solar_Tracker.SolarTrackerAPI.Models;
using Solar_Tracker.SolarTrackerAPI.Repository.Interface;

namespace Solar_Tracker.SolarTrackerAPI.Repository
{
    public class PlacaSolarRepository : IPlacaSolarRepository
    {

        private readonly dbContext dbContext;

        public PlacaSolarRepository(dbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<PlacaSolar> AddPlaca(PlacaSolar placa)
        {
            var result = await dbContext.PlacaSolares.AddAsync(placa);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<IEnumerable<PlacaSolar>> GetPlacas()
        {
            return await dbContext.PlacaSolares.ToListAsync();
        }
    }
}
