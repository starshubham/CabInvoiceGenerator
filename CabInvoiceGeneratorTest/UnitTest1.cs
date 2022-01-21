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
        /// UC2 : Test case for calculate fare function for multiple rides summary.
        /// </summary>
        [Test]
        public void GivenMultipleRidesShouldReturnInvoiceSummary()
        {
            // Creating Instance of InvoiceGenerator For Normal Ride.
            //Arrange
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };

            //Act
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 30.0);

            //Assert
            Assert.AreEqual(expectedSummary, summary);
        }

        /// <summary>
        /// UC3 : TestCase for Checking Calculate Fare Function For Minimum Time And Distance
        /// </summary>
        [Test]
        public void GivenLessDistanceOrTimeShouldReturnMinimumFare()
        {
            //Creating Instance of InvoiceGenerator for Normal Ride
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double distance = 0.1;
            int time = 1;

            //Calculating Fare
            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 5;

            //Asserting values
            Assert.AreEqual(expected, fare, time);
        }

        /// <summary>
        /// UC4 : Given Invalid RideType Should Throw Custom Exception
        /// </summary>
        [Test]
        public void GivenInvalidRideTypeShouldThrowCustomException()
        {
            //Creating Instance of InvoiceGenerator
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double distance = 2.0;
            int time = 5;
            string expected = "Invalid Ride Type";
            try
            {
                //Calculating Fare
                double fare = invoiceGenerator.CalculateFare(distance, time);
            }
            catch (CabInvoiceException exception)
            {
                //Asserting Values
                Assert.AreEqual(expected, exception);
            }
        }
    }
}