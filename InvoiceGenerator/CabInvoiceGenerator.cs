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
        public double CalculateFair (double distance, double time)
            {
            double result= (distance* COST_PER_KM) +(time*COST_PER_MINUTE);
            if (result < MINIMUM_FAIR)
                return MINIMUM_FAIR;
            else
                return result;
            }
    }
}
