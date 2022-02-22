using CoreServices.DTOs;
using System.Threading.Tasks;

namespace CoreServices.Interfaces
{
    public interface IAmenity
    {
        Task<AmenityDTO> Create(AmenityDTO amenity);
        Task<JSONRes<AmenitiesDTO>> GetAmenites();
        Task<AmenityDTO> GetAmenity(int id);
        Task<AmenityDTO> UpdateAmenity(int id, AmenityDTO amenity);
        Task Delete(int id);

    }
}
