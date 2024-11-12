using Solar_Tracker.Data;
using Solar_Tracker.Models;
using Solar_Tracker.Repository.Interface;

namespace Solar_Tracker.Repository
{
    public class PlacaSolarRepository : IPlacaSolarRepository
    {

        private readonly dbContext dbContext;

        public PlacaSolarRepository(dbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<PlacaSolar> AddPlaca(PlacaSolar placa)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PlacaSolar>> GetPlacas()
        {
            throw new NotImplementedException();
        }
    }
}
