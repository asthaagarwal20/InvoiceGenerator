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
        List<Ride> rides=new List<Ride>();
        public double CalculateFair (double distance, double time)
            {
            double result= (distance* COST_PER_KM) +(time*COST_PER_MINUTE);
            if (result < MINIMUM_FAIR)
                return MINIMUM_FAIR;
            else
                return result;
            }
        public void AddRide(int distance,int time)
        {
            rides.Add(new Ride()
            {
                distance = distance,
                time = time,
            });
        }
        public double CalculateAggregate()
        {
            double fair = 0;
            foreach(Ride ride in rides)
            {
                fair+=CalculateFair(ride.distance,ride.time);
            }
            return fair;
        }
    }
}
