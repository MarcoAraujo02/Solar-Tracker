using Solar_Tracker.Models;

namespace Solar_Tracker.Repository.Interface
{
    public interface IPlacaSolarRepository
    {

        Task<IEnumerable<PlacaSolar>> GetPlacas();
        Task<PlacaSolar> AddPlaca(PlacaSolar placa);
    }
}
