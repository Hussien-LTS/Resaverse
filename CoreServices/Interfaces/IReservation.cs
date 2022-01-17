using CoreModels.Models;
using CoreServices.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreServices.Interfaces
{
    public interface IReservation
    {
        ReservationDTO Create(ReservationDTO reservation);
        List<ReservationsDTO> GetReservations();
        List<ReservationsDTO> GetReservationsForUser(int userId);
        ReservationDTO GetReservation(int roomId, DateTime startTime);
        ReservationDTO UpdateReservation(int roomId, DateTime startTime, Reservation reservation);
        Task Delete(int roomId, DateTime startTime);
    }
}
