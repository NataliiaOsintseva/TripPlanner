using System.Collections.Generic;

namespace Travel.Models
{
    public interface ITravelRepository
    {
        IEnumerable<Trip> GetAllTrips();
        IEnumerable<Trip> GetAllTripsWithStops();
        void AddTrip(Trip newTrip);
        bool SaveAll();
        Trip GetTripByName(string tripName, string username);
        void AddStop(string tripName, string username, Stop newStop);
        IEnumerable<Trip> GetUserTripsWithStops(string name);
    }
}
