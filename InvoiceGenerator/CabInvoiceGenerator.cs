using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceGenerator
{
    public class CabInvoiceGenerator
    {
        const int COST_PER_KM = 10;
        const int COST_PER_MINUTE = 1;
        const double MINIMUM_FAIR = 5;
        List<Ride> rides = new List<Ride>();
        RideRepository rideRepository = new RideRepository();
        public double CalculateFair(double distance, double time)
        {
            double result = (distance * COST_PER_KM) + (time * COST_PER_MINUTE);
            if (result < MINIMUM_FAIR)
                return MINIMUM_FAIR;
            else
                return result;
        }
        public void AddRide(string name, int distance, int time)
        { 
            var userRides = rideRepository.GetRideByUserId(name);
            if (userRides == null)
            {
                var userRide = new List<Ride>();
                userRide.Add(new Ride()
                {
                    distance = distance,
                    time = time,
                });
                rideRepository.AddRideInRepo(name, userRide);
            }
            else
            {
                userRides.Add(new Ride()
                {
                    distance = distance,
                    time = time,
                });
                rideRepository.AddRideInRepo(name, userRides);
            }
        }
        public InvoiceSummary CalculateAggregate(string user)
        {
            var userRides = rideRepository.GetRideByUserId(user);
            double fair = 0;
            foreach(Ride ride in userRides)
            {
                fair+=CalculateFair(ride.distance,ride.time);
            }
            var summary = new InvoiceSummary()
            {
                no_of_rides = userRides.Count,
                avgFare=fair/userRides.Count,
                totalFare=fair
            };
            return summary;
        }
    }
}
