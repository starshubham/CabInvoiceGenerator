using CabInvoiceGenerator;
using NUnit.Framework;

namespace CabInvoiceGeneratorTest
{
    public class Tests
    {
        // InvoiceGenerator Reference
        InvoiceGenerator invoiceGenerator = null;

        /// <summary>
        /// UC1 : Test case for checking total fare function.
        /// </summary>
        [Test]
        public void GivenDistanceAndTimeShouldReturnTotalFare()
        {
            // Creating Instance of InvoiceGenerator For Normal Ride
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double distance = 2.0;
            int time = 5;

            // Calculating Fare
            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 25;

            // Asserting Values
            Assert.AreEqual(expected, fare);
        }

        /// <summary>
        /// UC2 : Test case for checking total fare for multiple rides.
        /// </summary>
        [Test]
        public void GivenMultipleRidesShouldReturnInvoiceSummary()
        {
            // Creating Instance of InvoiceGenerator For Normal Ride.
            //Arrange
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };
            double expected = 30;

            //Act
            double totalFare = invoiceGenerator.CalculateFare(rides);

            //Assert
            Assert.AreEqual(expected, totalFare);
        }
    }
}