using CoreServices.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreServices.Interfaces
{
    public interface IAmenity
    {
        List<AmenitiesDTO> GetAmenites();
        AmenityDTO GetAmenityDTO(int id);
        AmenityDTO Create(AmenityDTO Amenity);
        AmenityDTO UpdateAmenityDTO(int id, AmenityDTO amenity);
        Task Delete(int id);

    }
}
