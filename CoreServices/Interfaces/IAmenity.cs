using CoreServices.DTOs;
using System.Threading.Tasks;

namespace CoreServices.Interfaces
{
    public interface IAmenity
    {
        Task<AmenityDTO> Create(AmenityDTO amenity);
        Task Delete(int id);
        Task<JSONRes<AmenitiesDTO>> GetAmenites();
        Task<AmenityDTO> GetAmenityDTO(int id);
        Task<AmenityDTO> UpdateAmenityDTO(int id, AmenityDTO amenity);

    }
}
