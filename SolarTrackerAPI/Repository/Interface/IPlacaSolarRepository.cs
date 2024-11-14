using Solar_Tracker.SolarTrackerAPI.Models;

namespace Solar_Tracker.SolarTrackerAPI.Repository.Interface
{
    public interface IPlacaSolarRepository
    {

        Task<IEnumerable<PlacaSolar>> GetPlacas();
        Task<PlacaSolar> AddPlaca(PlacaSolar placa);
    }
}
