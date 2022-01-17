using CoreModels.Models;
using CoreServices.DTOs;
using CoreServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreServices.Services
{
    public class ReservationService : IReservation
    {
        public ReservationDTO Create(ReservationDTO reservation)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int roomId, DateTime startTime)
        {
            throw new NotImplementedException();
        }

        public ReservationDTO GetReservation(int roomId, DateTime startTime)
        {
            throw new NotImplementedException();
        }

        public List<ReservationsDTO> GetReservations()
        {
            throw new NotImplementedException();
        }

        public List<ReservationsDTO> GetReservationsForUser(int userId)
        {
            throw new NotImplementedException();
        }

        public ReservationDTO UpdateReservation(int roomId, DateTime startTime, Reservation reservation)
        {
            throw new NotImplementedException();
        }
    }
}
