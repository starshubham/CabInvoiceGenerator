using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    /// <summary>
    /// InvoiceGenerator Class to Generate the Invoice
    /// </summary>
    public class InvoiceGenerator
    {
        // Variable
        RideType rideType;
        private RideRepository rideRepository;

        // Constants
        private readonly double MINIMUM_COST_PER_KM;
        private readonly int COST_PER_TIME;
        private readonly double MINIMUM_FARE;

        /// <summary>
        /// Constructor to Create RideRepository instance.
        /// </summary>
        /// <param name="rideType"></param>
        /// <exception cref="CabInvoiceException"></exception>
        public InvoiceGenerator(RideType rideType)
        {
            this.rideType = rideType;
            this.rideRepository = new RideRepository();
            try
            {
                // If Ride Type is Premium then Rates Set for Premium else For Normal.
                if (rideType.Equals(RideType.PREMIUM))
                {
                    this.MINIMUM_COST_PER_KM = 15;
                    this.COST_PER_TIME = 2;
                    this.MINIMUM_FARE = 20;
                }
                else if (rideType.Equals(RideType.NORMAL))
                {
                    this.MINIMUM_COST_PER_KM = 10;
                    this.COST_PER_TIME = 1;
                    this.MINIMUM_FARE = 5;
                }
            }
            catch (CabInvoiceException)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_RIDE_TYPE, "Invalid Ride Type");
            }
        }

        /// <summary>
        /// Function to Calculate Fare.
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        /// <exception cref="CabInvoiceException"></exception>
        public double CalculateFare(double distance, int time)
        {
            double totalFare = 0;
            try
            {
                // Calculating Total Fare.
                totalFare = distance * MINIMUM_COST_PER_KM + time * COST_PER_TIME;
            }
            catch (CabInvoiceException)
            {
                if (rideType.Equals(null))
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_RIDE_TYPE, "Invalid Ride Type");
                }
                if (distance <= 0)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_DISTANCE, "Invalid Distance");
                }
                if (time < 0)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_TIME, "Invalid Time");
                }
            }
            return Math.Max(totalFare, MINIMUM_FARE);
        }


        /// <summary>
        /// Function to Calculate Total Fare and Generating Summary for Multiple Rides.
        /// </summary>
        /// <param name="rides"></param>
        /// <returns></returns>
        /// <exception cref="CabInvoiceException"></exception>
        public InvoiceSummary CalculateFare(Ride[] rides)
        {
            double totalFare = 0;
            try
            {
                foreach (Ride ride in rides)
                {
                    totalFare += this.CalculateFare(ride.distance, ride.time);
                }
            }
            catch (CabInvoiceException)
            {
                if (rides == null)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "Rides Are Null");
                }
            }
            return new InvoiceSummary(rides.Length, totalFare);
        }

        /// <summary>
        /// Function to Add Rides for UserId.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="rides"></param>
        /// <exception cref="CabInvoiceException"></exception>
        public void AddRides(string userId, Ride[] rides)
        {
            try
            {
                // Adding Riding to the Specific User.
                rideRepository.AddRide(userId, rides);
            }
            catch (CabInvoiceException)
            {
                if (rides == null)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "Ride Are Null");
                }
            }
        }

        /// <summary>
        /// Function to Get Summary By UserId.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        /// <exception cref="CabInvoiceException"></exception>
        public InvoiceSummary GetInvoiceSummary(string userId)
        {
            try
            {
                return this.CalculateFare(rideRepository.GetRides(userId));
            }
            catch (CabInvoiceException)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_USER_ID, "Invalid User Id");
            }
        }

    }
}
