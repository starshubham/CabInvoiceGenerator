using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    /// <summary>
    /// Ride class to Set Data for Particular Ride
    /// </summary>
    public class Ride
    {
        // Variables
        public double distance;
        public int time;

        /// <summary>
        /// Parameterise Constructor for Setting Data.
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="time"></param>
        public Ride(double distance, int time)
        {
            this.distance = distance;
            this.time = time;
        }
    }
}
